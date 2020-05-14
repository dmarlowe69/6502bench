﻿/*
 * Copyright 2020 faddenSoft
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CommonUtil {
    public static class Font8x8 {
        public static int[] GetBitData(char ch) {
            if (sBitData == null) {
                InitBitData();
            }

            int index = MapChar(ch);
            return sBitData[index];
        }

        private static int MapChar(char ch) {
            if (ch == ' ') {
                return 1;
            } else if (ch >= '0' && ch <= '9') {
                return ch - '0' + 2;
            } else if (ch >= 'A' && ch <= 'F') {
                return ch - 'A' + 12;
            } else {
                return 0;
            }
        }

        private static List<int[]> sBitData;

        /// <summary>
        /// Converts the easy-to-edit string data into easy-to-process bitmaps.
        /// </summary>
        private static void InitBitData() {
            Debug.Assert(sBitData == null);
            sBitData = new List<int[]>(sFontData.Length);

            for (int i = 0; i < sFontData.Length; i++) {
                int[] bits = new int[8];
                string str = sFontData[i];

                for (int row = 0; row < 8; row++) {
                    byte data = 0;
                    for (int col = 0; col < 8; col++) {
                        data <<= 1;

                        char ch = str[row * 8 + col];
                        if (ch == '#') {
                            data |= 1;
                        } else if (ch != '.') {
                            Debug.WriteLine("Unknown char '" + ch + "' in Font8x8 data " + i);
                        }
                    }

                    bits[row] = data;
                }

                sBitData.Add(bits);
            }
        }

        private static string[] sFontData = {
            // unknown value (U+FFFD)
            "..###..." +
            ".#####.." +
            "###.###." +
            "##.#.##." +
            "###.###." +
            ".#####.." +
            "..##...." +
            "........",

            // ' '
            "........" +
            "........" +
            "........" +
            "........" +
            "........" +
            "........" +
            "........" +
            "........",

            // '0'
            ".#####.." +
            "#.....#." +
            "#...#.#." +
            "#..#..#." +
            "#.#...#." +
            "#.....#." +
            ".#####.." +
            "........",
            // '1'
            "...#...." +
            "..##...." +
            ".#.#...." +
            "...#...." +
            "...#...." +
            "...#...." +
            ".#####.." +
            "........",
            // '2'
            ".#####.." +
            "#.....#." +
            "......#." +
            ".#####.." +
            "#......." +
            "#......." +
            "#######." +
            "........",
            // '3'
            "######.." +
            "......#." +
            "......#." +
            ".#####.." +
            "......#." +
            "......#." +
            "######.." +
            "........",
            // '4'
            ".....#.." +
            "....##.." +
            "...#.#.." +
            "..#..#.." +
            ".#...#.." +
            "#######." +
            ".....#.." +
            "........",
            // '5'
            "#######." +
            "#......." +
            "#......." +
            ".#####.." +
            "......#." +
            "#.....#." +
            ".#####.." +
            "........",
            // '6'
            ".#####.." +
            "#.....#." +
            "#......." +
            "######.." +
            "#.....#." +
            "#.....#." +
            ".#####.." +
            "........",
            // ' '
            "#######." +
            "......#." +
            ".....#.." +
            "....#..." +
            "...#...." +
            "..#....." +
            ".#......" +
            "........",
            // ' '
            ".#####.." +
            "#.....#." +
            "#.....#." +
            ".#####.." +
            "#.....#." +
            "#.....#." +
            ".#####.." +
            "........",
            // '9'
            ".#####.." +
            "#.....#." +
            "#.....#." +
            ".######." +
            "......#." +
            "......#." +
            ".#####.." +
            "........",

            // 'A'
            "...#...." +
            "..#.#..." +
            ".#...#.." +
            "#######." +
            "#.....#." +
            "#.....#." +
            "#.....#." +
            "........",
            // 'B'
            "######.." +
            "#.....#." +
            "#.....#." +
            "######.." +
            "#.....#." +
            "#.....#." +
            "######.." +
            "........",
            // 'C'
            ".#####.." +
            "#.....#." +
            "#......." +
            "#......." +
            "#......." +
            "#.....#." +
            ".#####.." +
            "........",
            // 'D'
            "######.." +
            "#.....#." +
            "#.....#." +
            "#.....#." +
            "#.....#." +
            "#.....#." +
            "######.." +
            "........",
            // 'E'
            "#######." +
            "#......." +
            "#......." +
            "######.." +
            "#......." +
            "#......." +
            "#######." +
            "........",
            // 'F'
            "#######." +
            "#......." +
            "#......." +
            "######.." +
            "#......." +
            "#......." +
            "#......." +
            "........",
        };
    }
}
