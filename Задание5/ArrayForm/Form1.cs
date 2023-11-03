using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayClass;
using System.Windows.Forms;

namespace ArrayForm
{
    public partial class Form1 : Form
    {
        int[] _array;
        int[] _resultArray;
        int[] _removedIndexes;
        int _length;
        bool _isGenerated;
        Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод вывода массива в DataGridView
        /// </summary>
        /// <param name="array">Массив для вывода</param>
        /// <param name="dg">Элемент DataGridView</param>
        private void DisplayArray(int[] array, DataGridView dg)
        {
            dg.ColumnCount = array.Length;
            // Установка кол-ва рядов, если оно нулевое.
            if (dg.RowCount == 0) dg.RowCount = 1;
            for(int i = 0; i < array.Length; i++)
            {
                dg.Columns[i].HeaderText = $"{i}";
                dg.Rows[0].Cells[i].Value = array[i];
            }
        }
        /// <summary>
        /// Метод вывода массива в ListBox
        /// </summary>
        /// <param name="_array">Массив для вывода</param>
        /// <param name="lb">Элемент ListBox</param>
        private void DisplayListBox(int[] _array, ListBox lb)
        {
            // Очистка элемента ListBox.
            lb.Items.Clear();
            // Заполнение элемента новыми значениями.
            for(int i = 0; i < _array.Length; i++) lb.Items.Add(_array[i]);
        }
        /// <summary>
        /// Метод нажатия на кнопку calculateButton
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e">Аргументы</param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Сбрасываем DataGridView результатов.
                resultArrayGrid.RowCount = 0;
                resultArrayGrid.ColumnCount = 0;
                _resultArray = ArrayClass.ArrayClass.RemoveDividableNumbers(_array, (int)dividerField.Value, out _removedIndexes);
                if (_removedIndexes.Length > 0)
                {
                    DisplayArray(_resultArray, resultArrayGrid);
                    DisplayListBox(_removedIndexes, removedIndexesBox);
                }
                else MessageBox.Show(this, $"В массиве нету элементов, делящихся на {(int)dividerField.Value}", "Результат расчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrayLengthField_ValueChanged(object sender, EventArgs e)
        {
            // Очищаем элементы, которые зависят от длины массива (список удаленных индексов).
            removedIndexesBox.Items.Clear();
            // Также сбрасываем цвета у datagrid.
            if (baseArrayGrid.RowCount > 0)
            {
                for (int i = 0; i < baseArrayGrid.Rows[0].Cells.Count; i++) baseArrayGrid.Rows[0].Cells[i].Style.BackColor = SystemColors.Window;
            }
            // Устанавливаем кол-во рядов, если оно не задано.
            if (baseArrayGrid.RowCount != 1 && arrayLengthField.Value > 0) baseArrayGrid.RowCount = 1;
            // Изменяем кол-во колонок и устанавливаем им заголовки.
            baseArrayGrid.ColumnCount = (int)arrayLengthField.Value;
            for (int i = 0; i < arrayLengthField.Value; i++)
            {
                baseArrayGrid.Columns[i].HeaderText = $"{i}";
            }
            
            _length = (int)arrayLengthField.Value;
            _array = new int[_length];

            // Разблокировываем кнопку.
            arrayFillButton.Enabled = _length != 0 ? true : false;
            // И блокируем кнопку вычисления.
            calculateButton.Enabled = false;
            _isGenerated = false;

        }

        private void BaseArrayGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(InputFiltering);
        }

        private void InputFiltering(object sender, KeyPressEventArgs e)
        {
            // Смена типа.
            DataGridViewTextBoxEditingControl t = (DataGridViewTextBoxEditingControl)sender;
            
            if (t.Text.Length >= 4 && e.KeyChar != '\b' && e.KeyChar != '-') e.KeyChar = '\0';
            if (t.Text.Contains("-") && t.SelectionStart <= t.Text.IndexOf("-")) e.KeyChar = '\0';
            if (e.KeyChar == '-' && (t.SelectionStart != 0 || t.Text.Contains("-"))) e.KeyChar = '\0';

            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == '\b')) e.KeyChar = '\0';
        }

        private void ArrayFillButton_Click(object sender, EventArgs e)
        {
            // Очищаем элементы, которые зависят от длины массива (список удаленных индексов).
            removedIndexesBox.Items.Clear();
            // Также сбрасываем цвета у datagrid.
            if (baseArrayGrid.RowCount > 0)
            {
                for (int i = 0; i < baseArrayGrid.Rows[0].Cells.Count; i++) baseArrayGrid.Rows[0].Cells[i].Style.BackColor = SystemColors.Window;
            }

            try
            {
                if (randomFillButton.Checked)
                {
                    for (int i = 0; i < _length; i++) _array[i] = _rnd.Next((int)lowerRandomBound.Value, (int)upperRandomBound.Value);
                    DisplayArray(_array, baseArrayGrid);
                }
                else
                {
                    for (int i = 0; i < _length; i++)
                    {
                        if (!int.TryParse(baseArrayGrid.Rows[0].Cells[i].Value.ToString(), out _array[i])) throw new Exception($"Не удалось преобразовать {i}-й элемент!");
                    }
                }
                _isGenerated = true;
                // Разблокировываем, если введен делитель.
                if ((int)dividerField.Value != 0) calculateButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RandomFillButton_CheckedChanged(object sender, EventArgs e)
        {
            arrayFillButton.Text = "Сгенерировать массив";
            baseArrayGrid.ReadOnly = true;
        }

        private void ManualFillButton_CheckedChanged(object sender, EventArgs e)
        {
            arrayFillButton.Text = "Подтвердить ввод";
            baseArrayGrid.ReadOnly = false;
        }
        // Метод выделения элемента вводимого массива по индексу.
        private void RemovedIndexesBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Сброс цвета всех ячеек.
                for (int i = 0; i < baseArrayGrid.Rows[0].Cells.Count; i++) baseArrayGrid.Rows[0].Cells[i].Style.BackColor = SystemColors.Window;
                int index = Convert.ToInt16(removedIndexesBox.SelectedItem);
                if (baseArrayGrid.Rows[0].Cells.Count - 1 < index) throw new Exception("Такого индекса не существует (скорее всего, была изменена длина массива)");
                baseArrayGrid.Rows[0].Cells[index].Style.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DividerField_ValueChanged(object sender, EventArgs e)
        {
            calculateButton.Enabled = ((int)dividerField.Value != 0 && _isGenerated) ? true : false;
        }
    }
}
