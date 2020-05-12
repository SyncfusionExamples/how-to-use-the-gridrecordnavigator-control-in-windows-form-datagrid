# How to use the GridRecordNavigator control in windows form SfDataGrid
## About the sample
This example illustrates how to use the GridRecordNavigator control in windows form DataGrid.

By default, SfDataGrid does not support for GridRecordNavigationBar. But we can achieve this by change the selection based on navigation buttons.

## Navigate to next row 

```c#
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
```

## Navigate to previous row 

```c#
private void previous_Click(object sender, EventArgs e)
{
    if (this.sfDataGrid1.SelectedIndex > 0)
        this.sfDataGrid1.SelectedIndex = this.sfDataGrid1.SelectedIndex - 1;
    selectedIndex = this.sfDataGrid1.SelectedIndex +1;
    this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.CurrentCell.RowIndex);
    this.sfDataGrid1.TableControl.UpdateScrollBars();
    label1.Text = "Record \t" + selectedIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
}

```

## Navigate to last row 

```c#
private void last_Click(object sender, EventArgs e)
{
    var getLastRowIndex = typeof(SelectionHelper).GetMethod("GetLastRowIndex", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    var lastRowIndex = (int)getLastRowIndex.Invoke(typeof(SelectionHelper), new object[] { this.sfDataGrid1 });

    this.sfDataGrid1.SelectedIndex = lastRowIndex - 1;

    this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.SelectedIndex);
    this.sfDataGrid1.TableControl.UpdateScrollBars();

    label1.Text = "Record \t" + lastRowIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);

} 
```

## Navigate to first row 

```c#
private void first_Click(object sender, EventArgs e)
{
    var getFirstDataRowIndex = typeof(SelectionHelper).GetMethod("GetFirstRowIndex", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    var firstRowIndex = (int)getFirstDataRowIndex.Invoke(typeof(SelectionHelper), new object[] { this.sfDataGrid1 });

    this.sfDataGrid1.SelectedIndex = firstRowIndex - 1;

    this.sfDataGrid1.TableControl.ScrollRows.ScrollInView(this.sfDataGrid1.SelectedIndex);
    this.sfDataGrid1.TableControl.UpdateScrollBars();
    label1.Text = "Record \t" + firstRowIndex.ToString() + "of" + (this.sfDataGrid1.TableControl.ScrollRows.LineCount - this.sfDataGrid1.TableControl.ScrollRows.HeaderLineCount);
}
```
## Requirements to run the demo
Visual Studio 2015 and above versions
