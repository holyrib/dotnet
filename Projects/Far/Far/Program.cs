﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 150);
            Console.CursorVisible = false;
            Stack<FileSystemInfo[]> parent = new Stack<FileSystemInfo[]>();
            Stack<int> indexhist = new Stack<int>();
            string[] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] cur = new FileSystemInfo[drives.Length];
            for (int i = 0; i < cur.Length; i++)
                cur[i] = new DirectoryInfo(drives[i]);

            int index = 0;
            Show(cur, index);

            ConsoleKeyInfo pressed = Console.ReadKey(true);
            while (pressed.Key != ConsoleKey.Escape)
            {
                switch (pressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (cur.Length > index + 1)
                            index++;
                        else index = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        else index = cur.Length - 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (parent.Count > 0)
                        {
                            index = indexhist.Pop();
                            cur = parent.Pop();
                        }

                        break;

                    case ConsoleKey.RightArrow:
                        if (cur[index] is DirectoryInfo)
                        {
                            try
                            {
                                DirectoryInfo dir = cur[index] as DirectoryInfo;
                                indexhist.Push(index);
                                parent.Push(cur);
                                index = 0;
                                cur = dir.GetFileSystemInfos();

                            }
                            catch (Exception e)
                            {

                            }
                        }
                        else System.Diagnostics.Process.Start(cur[index].FullName);
                        break;

                }
                Show(cur, index);
                pressed = Console.ReadKey(true);
            }

        }
        #region drawing
        static void Draw(string text, ConsoleColor fore, bool nl)
        {
            Console.ForegroundColor = fore;
            Console.Write(text);
            if (nl) Console.WriteLine();
        }
        static void Draw(string text, ConsoleColor fore, ConsoleColor back, bool nl)
        {
            Console.BackgroundColor = back;
            Draw(text, fore, nl);

        }
        #endregion

        static void Show(FileSystemInfo[] cur, int index)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int ind = 0;
            foreach (FileSystemInfo fsi in cur)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (ind++ == index) Console.BackgroundColor = ConsoleColor.Red;
                String disp = fsi.Name.Length < 20 ? fsi.Name : fsi.Name.Substring(0, 20);
                if (fsi is DirectoryInfo)
                {
                    Draw("[+]", ConsoleColor.Green, false);
                    Draw(disp, ConsoleColor.Gray, true);
                }

                else
                {

                    Draw(disp, ConsoleColor.White, true);
                }
            }
        }
    }
    
}
