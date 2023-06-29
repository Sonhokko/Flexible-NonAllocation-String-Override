using System;
using TMPro;
using UnityEngine.UI;

public class StringPolymorph
{
    private readonly Text m_text;
    
    public StringPolymorph(Text text)
    {
        this.m_text = text;
    }

    public void ChangeString(ref string str, int value)
    {
        CleanString(ref str);
        m_text.text = str;
        OverrideString(ref str, value);
        m_text.cachedTextGenerator.Invalidate();
        m_text.SetVerticesDirty();
    }
    
    public void ChangeStringFlexible(ref string str, int value, in char inputChar)
    {
        CleanString(ref str);
        m_text.text = str;
        FlexibleOverrideString(ref str, value, in inputChar);
        m_text.cachedTextGenerator.Invalidate();
        m_text.SetVerticesDirty();
    }
    
    private unsafe void CleanString(ref string str)
    {
        fixed (char* ptr = str)
        {
            int length = str.Length;

            for (int i = 0; i < length; i++)
                *(ptr + i) = '\0';
        }
    }

    private unsafe Span<char> OverrideString(ref string str, int size)
    {
        fixed (char* ptr = str)
        {
            int length = str.Length;
            if (length > 0)
            {
                int remaining = size;
                int index = 0;

                do
                {
                    int digit = remaining % 10;
                    remaining /= 10;

                    *(ptr + index) = (char)('0' + digit);
                    index++;
                } while (remaining > 0);
            }

            return new Span<char>(ptr, length);
        }
    }

    private unsafe Span<char> FlexibleOverrideString(ref string str, int size, in char inputChar)
    {
        fixed (char* ptr = str)
        {
            *(ptr + 0) = inputChar;
            
            int length = str.Length;
            if (length > 0)
            {
                int remaining = size;
                int index = 1;

                do
                {
                    int digit = remaining % 10;
                    remaining /= 10;

                    *(ptr + index) = (char)('0' + digit);
                    index++;
                } while (remaining > 0);
            }

            return new Span<char>(ptr, length);
        }
    }
}
