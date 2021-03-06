﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sage.Platform.Design;
using Sage.Platform.QuickForms.Controls;
using System.ComponentModel;


/*
   OpenSlx - Open Source SalesLogix Library and Tools
   Copyright 2010 nicocrm (http://github.com/ngaller/OpenSlx)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace OpenSlx.Lib.QuickForms.Editors
{
    /// <summary>
    /// Used to select a "QFEntityDataSource"
    /// </summary>
    public class DataSourceSelectEditor : ListBoxTypeEditor
    {
        protected override IEnumerable<string> GetValues(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            QuickFormsControlBase control = context.Instance as QuickFormsControlBase;
            if (control == null)
            {
                throw new InvalidOperationException("Invalid context - null instance (or not a QuickFormsControl)");
            }
            return control.QuickFormDefinition.AllControls
                .Where(x => x is QFEntityDataSource)
                .OrderBy(x => x.ControlId)
                .Select(x => x.ControlId);
        }
    }
}
