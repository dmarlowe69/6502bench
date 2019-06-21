﻿/*
 * Copyright 2018 faddenSoft
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
using System.Windows;

namespace SourceGenWPF.WpfGui {
    /// <summary>
    /// Report a problem encountered while loading a data file.
    /// </summary>
    public partial class DataFileLoadIssue : Window {
        /// <summary>
        /// Path name of problematic file.
        /// </summary>
        public string PathName { get; set; }

        /// <summary>
        /// Message to show in the dialog.
        /// </summary>
        public string Message { get; set; }


        public DataFileLoadIssue(Window owner, string pathName, string message) {
            PathName = pathName;
            Message = message;

            this.DataContext = this;
            InitializeComponent();
            Owner = owner;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }
    }
}
