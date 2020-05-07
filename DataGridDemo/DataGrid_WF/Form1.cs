using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid_WF
{
    public partial class Form1 : Form
    {
        ObservableCollection<OrderInfo> list = new ObservableCollection<OrderInfo>();

        int selectedIndex;
        public Form1()
        {
            InitializeComponent();

            list.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", new DateTime(2020,06,12)));
            list.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.",null));
            list.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid",null));
            list.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille",null));
            list.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1011, "Maria Anders", "Germany", "ALFKI", "Berlin", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1012, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.", null));
            list.Add(new OrderInfo(1013, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1014, "Thomas Hardy", "UK", "AROUT", "London", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1015, "Christina Berglund", "Sweden", "BERGS", "Lula", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1016, "Hanna Moos", "Germany", "BLAUS", "Mannheim", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1017, "Frederique Citeaux", "France", "BLONP", "Strasbourg", new DateTime(2020, 06, 12)));
            list.Add(new OrderInfo(1018, "Martin Sommer", "Spain", "BOLID", "Madrid", null));
            list.Add(new OrderInfo(1019, "Laurence Lebihan", "France", "BONAP", "Marseille", null));
            list.Add(new OrderInfo(1020, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", new DateTime(2020, 06, 12)));

            this.sfDataGrid1.AutoGenerateColumns = true;


            this.sfDataGrid1.DataSource = list;

            this.sfDataGrid1.SelectionChanged += SfDataGrid1_SelectionChanged;

           
        }

        private void SfDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = this.sfDataGrid1.SelectedIndex + 1;
            label1.Text = "Record \t" + selectedIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
        }

        private void first_Click(object sender, EventArgs e)
        {
            var getFirstDataRowIndex = typeof(SelectionHelper).GetMethod("GetFirstRowIndex", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            var firstRowIndex = (int)getFirstDataRowIndex.Invoke(typeof(SelectionHelper), new object[] { this.sfDataGrid1 });

            this.sfDataGrid1.SelectedIndex = firstRowIndex - 1;

            this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.SelectedIndex);
            this.sfDataGrid1.TableControl.UpdateScrollBars();
            label1.Text = "Record \t" + firstRowIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (this.sfDataGrid1.SelectedIndex > 0)
                this.sfDataGrid1.SelectedIndex = this.sfDataGrid1.SelectedIndex - 1;
            selectedIndex = this.sfDataGrid1.SelectedIndex +1;
            this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.CurrentCell.RowIndex);
            this.sfDataGrid1.TableControl.UpdateScrollBars();
            label1.Text = "Record \t" + selectedIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
        }

        private void next_Click(object sender, EventArgs e)
        {
            var tableControl = this.sfDataGrid1.TableControl;
            if (this.sfDataGrid1.SelectedIndex > -1 && (this.sfDataGrid1.TableControl.ResolveToRowIndex(this.sfDataGrid1.SelectedIndex + 1) != sfDataGrid1.RowCount))
            {
                this.sfDataGrid1.SelectedIndex = this.sfDataGrid1.SelectedIndex + 1;
                selectedIndex = this.sfDataGrid1.SelectedIndex + 1;
                this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.CurrentCell.RowIndex);
                this.sfDataGrid1.TableControl.UpdateScrollBars();
                label1.Text = "Record \t" + selectedIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            var getLastRowIndex = typeof(SelectionHelper).GetMethod("GetLastRowIndex", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            var lastRowIndex = (int)getLastRowIndex.Invoke(typeof(SelectionHelper), new object[] { this.sfDataGrid1 });

            this.sfDataGrid1.SelectedIndex = lastRowIndex - 1;

            this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.SelectedIndex);
            this.sfDataGrid1.TableControl.UpdateScrollBars();

            label1.Text = "Record \t" + lastRowIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);

        }
    }

   


}


