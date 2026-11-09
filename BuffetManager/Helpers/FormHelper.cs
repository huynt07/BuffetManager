using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BuffetManager.Helpers
{
    public static class FormHelper
    {
        public static bool Run(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException)
            {
                MessageBox.Show("Dữ liệu vừa được máy khác thay đổi. Hãy tải lại rồi thao tác lại.", "Thông báo");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Number == 1205 ? "Có thao tác đồng thời. Hãy tải lại dữ liệu rồi thử lại." : "Không thể ghi/đọc database. " + ex.Message, "Lỗi dữ liệu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        public static bool Confirm(string text)
        {
            return MessageBox.Show(text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static void Combo(ComboBox c, params string[] pairs)
        {
            var data = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < pairs.Length; i += 2)
                data.Add(new KeyValuePair<string, string>(pairs[i], pairs[i + 1]));
            c.DisplayMember = "Value";
            c.ValueMember = "Key";
            c.DataSource = data;
            c.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static string Value(ComboBox c)
        {
            return c.SelectedValue as string ?? "";
        }

        public static void Grid(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoGenerateColumns = true;
        }

        public static void Columns(DataGridView g, params string[] pairs)
        {
            foreach (DataGridViewColumn c in g.Columns)
                c.Visible = false;
            for (int i = 0; i < pairs.Length; i += 2)
                if (g.Columns.Contains(pairs[i]))
                {
                    var c = g.Columns[pairs[i]];
                    c.Visible = true;
                    c.HeaderText = pairs[i + 1];
                    c.DisplayIndex = i / 2;
                }
        }

        public static T Selected<T>(DataGridView g)
            where T : class
        {
            return g.CurrentRow == null ? null : g.CurrentRow.DataBoundItem as T;
        }

        public static void Money(DataGridView g, params string[] names)
        {
            foreach (var n in names)
                if (g.Columns.Contains(n))
                    g.Columns[n].DefaultCellStyle.Format = "N2";
        }
    }
}
