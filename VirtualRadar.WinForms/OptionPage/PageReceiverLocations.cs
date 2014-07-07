﻿// Copyright © 2014 onwards, Andrew Whewell
// All rights reserved.
//
// Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the author nor the names of the program's contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHORS OF THE SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualRadar.Localisation;
using VirtualRadar.Resources;
using VirtualRadar.WinForms.Binding;
using VirtualRadar.Interface.Settings;
using VirtualRadar.Interface.View;

namespace VirtualRadar.WinForms.OptionPage
{
    public partial class PageReceiverLocations : Page
    {
        private RecordListHelper<ReceiverLocation, PageReceiverLocation> _ListHelper;

        public override string PageTitle { get { return Strings.ReceiverLocationsTitle; } }

        public override Image PageIcon { get { return Images.Location16x16; } }

        public override bool PageUseFullHeight { get { return true; } }

        public ObservableList<ReceiverLocation> ReceiverLocations { get; private set; }

        public PageReceiverLocations()
        {
            InitializeComponent();
            InitialisePage();
        }

        protected override void CreateBindings()
        {
            ReceiverLocations = BindListProperty<ReceiverLocation>(listReceiverLocations);

            _ListHelper = new RecordListHelper<ReceiverLocation,PageReceiverLocation>(this, listReceiverLocations, ReceiverLocations);
        }

        private void listReceiverLocations_FetchRecordContent(object sender, Controls.BindingListView.RecordContentEventArgs e)
        {
            var record = (ReceiverLocation)e.Record;

            if(record != null) {
                e.ColumnTexts.Add(record.Name);
                e.ColumnTexts.Add(record.Latitude.ToString("N6"));
                e.ColumnTexts.Add(record.Longitude.ToString("N6"));
            }
        }

        protected override Page CreatePageForNewChildRecord(IObservableList observableList, object record)
        {
            return _ListHelper.CreatePageForNewChildRecord(observableList, record);
        }

        private void listReceiverLocations_AddClicked(object sender, EventArgs e)
        {
            _ListHelper.AddClicked(() => new ReceiverLocation() {
                UniqueId = GenerateUniqueId(1, ReceiverLocations.Value, r => r.UniqueId),
                Name = GenerateUniqueName(ReceiverLocations.Value, "Location", false, r => r.Name),
                Latitude = 0.0,
                Longitude = 0.0,
            });
        }

        private void listReceiverLocations_DeleteClicked(object sender, EventArgs e)
        {
            _ListHelper.DeleteClicked();
        }

        private void listReceiverLocations_EditClicked(object sender, EventArgs e)
        {
            _ListHelper.EditClicked();
        }

        private void linkLabelUpdateFromBaseStationDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptionsView.RaiseUpdateReceiverLocationsFromBaseStationDatabaseClicked(e);
        }
    }
}