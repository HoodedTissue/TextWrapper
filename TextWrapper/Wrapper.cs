using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextWrapper
{
    class Wrapper
    {
        private int index = 0;
        private int totalWidth = 715;

        public void wrapText(String[] lines, string path)
        {
            iterateArray(lines);
            createFile(lines, path);
        }

        public void iterateArray(String[] lines)
        {
            for (int arrayIndex = 0; arrayIndex < lines.Length; arrayIndex++)
            {
                index = 0;
                iterateCharacters(lines, arrayIndex);
            }
        }

        public void iterateCharacters(String[] lines, int arrayIndex)
        {
            for (int sentenceIndex = 0; sentenceIndex < lines[arrayIndex].Length; sentenceIndex++)
            {
                calculateWidth(lines, arrayIndex, sentenceIndex);
            }
        }

        public void calculateWidth(String[] lines, int arrayIndex, int sentenceIndex)
        {
            //calculate width of each character in sentence
            switch (lines[arrayIndex][sentenceIndex])
            {
                case '\\':
                case 'l':
                    index += 3;
                    break;
                case 'I':
                case '!':
                case ';':
                    index += 4;
                    break;
                case 'i':
                case ',':
                    index += 5;
                    break;
                case '\'':
                    index += 7;
                    break;
                case ' ':
                    index += 6;
                    break;
                case 'r':
                case '(':
                case ')':
                    index += 9;
                    break;
                case 'f':
                case 't':
                    index += 10;
                    break;
                case 'k':
                case 'J':
                case 's':
                case '-':
                    index += 12;
                    break;
                case 'h':
                case 'n':
                case 'u':
                case 'z':
                    index += 13;
                    break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'g':
                case 'p':
                case 'q':
                case 'v':
                case 'x':
                case 'y':
                case '?':
                    index += 14;
                    break;
                case 'E':
                case 'F':
                case 'K':
                case 'L':
                case 'o':
                    index += 15;
                    break;
                case 'S':
                    index += 16;
                    break;
                case 'B':
                case 'H':
                case 'N':
                case 'P':
                case 'R':
                case 'U':
                case 'Z':
                    index += 17;
                    break;
                case 'C':
                case 'D':
                case 'G':
                case 'Y':
                    index += 18;
                    break;
                case 'A':
                case 'T':
                case 'V':
                case 'X':
                    index += 19;
                    break;
                case 'M':
                case '&':
                    index += 20;
                    break;
                case 'm':
                case 'O':
                case 'Q':
                case '％':
                    index += 21;
                    break;
                case 'w':
                    index += 22;
                    break;
                case '―':
                    index += 24;
                    break;
                case 'W':
                    index += 26;
                    break;
                default:
                    index += 10;
                    break;
            }
            index += 2;
            addLineBreak(lines, arrayIndex, sentenceIndex);
        }

        public void addLineBreak(String[] lines, int arrayIndex, int sentenceIndex)
        {
            if (index > totalWidth)
            {
                for (int a = sentenceIndex; a < lines[arrayIndex].Length; a--)
                {
                    try
                    {
                        if (lines[arrayIndex][a] == ' ')
                        {
                            StringBuilder str = new StringBuilder(lines[arrayIndex]);
                            str.Remove(a, 1);
                            str.Insert(a, "\\n");
                            lines[arrayIndex] = str.ToString();
                            break;
                        }
                    } catch (IndexOutOfRangeException)
                    {
                        index = 0;
                        break;
                    }
                }
                index = 0;
            }
        }

        public void createFile(String[] lines, string path)
        {
            string fileName;
            string folderName = "out";
            fileName = Path.GetFileName(@path);
            System.IO.Directory.CreateDirectory(@folderName);
            string createOut = Path.Combine(folderName, fileName);
            using (StreamWriter sw = File.CreateText(@createOut))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
            }
        }
    }
}
