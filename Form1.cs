using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace ib_lab
{
    public partial class Form1 : Form
    {
        public class dec
        {
            string ab, key;
            public string[] input_text;

            public dec(string a, string k, string[] t)
            {
                ab = a;
                key = k;
                input_text = t;
            }

            public string[] XOR()
            {
                string[] output = new string[input_text.Length];
                int k = 0, x = 0, z = 0;
                string res = "";

                string str_input_text = "";

                for (int i = 0; i < input_text.Length; i++)
                    str_input_text += input_text[i] + ' ';

                // res = string.Empty;

                while (key.Length < str_input_text.Length)
                {
                    key += key;
                    if (key.Length > str_input_text.Length) key = key.Remove(str_input_text.Length);
                }

                for (int i = 0; i < (str_input_text.Length - 1); i++)
                {
                    // for (int id = 0; id < ab.Length; id++)
                    {
                        k = ab.IndexOf(key[i]); //           if (key[i] == ab[id]) k = id;
                        x = ab.IndexOf(str_input_text[i]); // if (str_input_text[i] == ab[id]) x = id;
                        if (x - k > 0)
                            z = (x - k) % ab.Length;
                        else
                            z = (ab.Length + x - k) % ab.Length;
                    }
                    res += ab[z];
                }
                output[0] = res;
                return output;
            } //done

            public string[] cesar() //done
            {
                System.Int32 a;
                if (!Int32.TryParse(key, out a) || a < 0)
                {
                    MessageBox.Show(
                        "Для правильной работы этого алгоритма ключ должен быть числовым положительным значением",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[input_text.Length];
                int num, int_key = Math.Abs(Int32.Parse(key)) % ab.Length;
                for (int i = 0; i < input_text.Length; i++)
                {
                    string newline = "";


                    foreach (char sym in input_text[i])
                    {
                        for (num = 0; num < ab.Length; num++)
                            if (ab[num] == sym) break;

                        if (num - int_key <= ab.Length - 1 && num - int_key >= 0)
                            newline += ab[num - int_key];

                        else if (num - int_key < 0)
                            newline += ab[ab.Length - int_key + num];

                        else
                            newline += ab[num + int_key + ab.Length];

                        output_text[i] = newline;
                    }
                }

                return output_text;
            }


            public string[] replace() //done
            {
                for (int i = 0; i < input_text.Length; i++)
                for (int j = 0; j < input_text[i].Length; j++)
                    if (key.IndexOf(input_text[i][j]) == -1)
                    {
                        MessageBox.Show("Некоторых символов, использованных в исходном тексте, нет в алфавите", "Ошибка",
                            MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }

                if (ab.Length != key.Length)
                {
                    MessageBox.Show("Длина алфавита и длина ключа не совпадает", "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[input_text.Length];

                for (int i = 0; i < input_text.Length; i++)
                {
                    string newline = "";
                    foreach (char sym in input_text[i])
                        newline += ab[key.IndexOf(sym)];
                    output_text[i] = newline;
                }
                return output_text;
            }

            public string[] block_enc()
            {
                Int32 a;
                if (!Int32.TryParse(key, out a))
                {
                    MessageBox.Show("Для правильной работы этого алгоритма ключ должен быть числовым значением",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[input_text.Length];
                int i, j;

                //парсим ключ
                for (i = 1; i <= key.Length; i++)
                    if (!key.Contains(Convert.ToString(i)))
                    {
                        MessageBox.Show("Ключ некорректен.", "Ошибка", MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }
                int block_size = key.Length;
                int[] block_order = new int[block_size];
                for (i = 0; i < block_size; i++)
                    block_order[i] = (int) Char.GetNumericValue(key[i]);

                //конвертируем весь текст в одну строку

                string tmp_str_input_text = "";

                for (i = 0; i < input_text.Length; i++)
                    tmp_str_input_text += input_text[i];

                int tail_l = tmp_str_input_text.Length % block_size;
                int enc_part_l = tmp_str_input_text.Length - tail_l;

                char[] str_input_text = new char[enc_part_l];
                char[] tail = new char[tail_l];

                for (i = 0; i < tmp_str_input_text.Length; i++)
                    if (i < enc_part_l)
                        str_input_text[i] = tmp_str_input_text[i];
                    else
                        tail[i - enc_part_l] = tmp_str_input_text[i];

                //основной алгоритм

                for (i = 0; i < str_input_text.Length; i += block_size)
                {
                    char[] block = new char[block_size]; //массив под текущий блок
                    char[] temp_block = new char[block_size];

                    //     for (j = i; j < i + block_size; j++)
                    //        block[j - i] = str_input_text[j];

                    for (j = i; j < i + block_size; j++)
                        temp_block[j - i] = str_input_text[j];

                    for (j = 0; j < block_size; j++)
                        block[block_order[j] - 1] = temp_block[j];

                    output_text[0] += new string(block);
                }
                output_text[0] += new string(tail);
                return output_text;
            } //done

            public string[] hard_block_enc() //done
            {
                //проверка на значение ключа

                System.Int32 a;
                if (!Int32.TryParse(key, out a))
                {
                    MessageBox.Show(
                        "Для правильной работы этого алгоритма ключ должен быть числовым значением, не превышающим 9",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[1];
                int i, j;

                //парсим и проверяем ключ
                for (i = 1; i <= key.Length; i++)
                    if (!key.Contains(Convert.ToString(i)))
                    {
                        MessageBox.Show("Ключ некорректен.", "Ошибка", MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }

                int block_size = key.Length;
                int[] block_order = new int[block_size];
                for (i = 0; i < block_size; i++)
                    block_order[i] = (int) Char.GetNumericValue(key[i]);

                //конвертируем весь текст в одну строку

                string tmp_str_input_text = null;

                for (i = 0; i < input_text.Length; i++)
                    tmp_str_input_text += input_text[i];

                int tail_l = tmp_str_input_text.Length % block_size;
                int enc_part_l = tmp_str_input_text.Length - tail_l;

                char[] str_input_text = new char[enc_part_l];
                char[] tail = new char[tail_l];

                for (i = 0; i < tmp_str_input_text.Length; i++)
                    if (i < enc_part_l)
                        str_input_text[i] = tmp_str_input_text[i];
                    else
                        tail[i - enc_part_l] = tmp_str_input_text[i];

                //основной алгоритм

                int k = 0;

                for (i = 0; i < str_input_text.Length; i += block_size)
                {
                    char[] block = new char[block_size]; //массив под текущий блок
                    char[] temp_block = new char[block_size];

                    //   for (j = i; j < i + block_size; j++)
                    //       block[j - i] = str_input_text[j];


                    for (j = i; j < i + block_size; j++)
                        temp_block[j - i] = str_input_text[j];

                    if (k % 2 != 0) Array.Reverse(temp_block);

                    for (j = 0; j < block_size; j++)
                        block[block_order[j] - 1] = temp_block[j];


                    //output_text[k] = new string(block);
                    output_text[0] += new string(block);

                    k++;
                }

                if (k % 2 != 0) Array.Reverse(tail);
                output_text[0] += new string(tail);
                //output_text[k] = new string(tail);
                return output_text;
            }
        }


        public class enc
        {
            string ab, key;
            public string[] input_text;

            public enc(string a, string k, string[] t)
            {
                ab = a;
                key = k;
                input_text = t;
            }

            public string[] XOR()
            {
                string[] output = new string[input_text.Length];
                int k = 0, x = 0, z = 0;
                string res;

                string str_input_text = "";

                for (int i = 0; i < input_text.Length; i++)
                    str_input_text += input_text[i] + ' ';

                res = string.Empty;

                while (key.Length < str_input_text.Length)
                {
                    key += key;
                    if (key.Length > str_input_text.Length) key = key.Remove(str_input_text.Length);
                }

                for (int i = 0; i < (str_input_text.Length - 1); i++)
                {
                    /*for (int id = 0; id < ab.Length; id++)
                    {
                        if (key[i] == ab[id]) k = id;
                        if (str_input_text[i] == ab[id]) x = id;
                        z = (x + k) % ab.Length;
                    }*/
                    k = ab.IndexOf(key[i]);
                    x = ab.IndexOf(str_input_text[i]);
                    z = (x + k) % ab.Length;
                    res += ab[z];
                }
                output[0] = res;
                return output;
            }

            public string[] cesar()
            {
                System.Int32 a;
                if (!Int32.TryParse(key, out a) || a < 0)
                {
                    MessageBox.Show(
                        "Для правильной работы этого алгоритма ключ должен быть числовым положительным значением",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[input_text.Length];

                for (int i = 0; i < input_text.Length; i++)
                {
                    string newline = "";
                    foreach (char sym in input_text[i])
                    {
                        int num, int_key = Math.Abs(Int32.Parse(key)) % ab.Length;

                        for (num = 0; num < ab.Length; num++)
                            if (ab[num] == sym) break;

                        if (num + int_key <= ab.Length - 1 && num + int_key >= 0)
                            newline += ab[num + int_key];

                        else if (num + int_key < 0)
                            newline += ab[ab.Length + int_key + num];

                        else
                            newline += ab[num + int_key - ab.Length];

                        output_text[i] = newline;
                    }
                }

                return output_text;
            }

            public string[] replace()
            {
                for (int i = 0; i < input_text.Length; i++)
                for (int j = 0; j < input_text[i].Length; j++)
                    if (key.IndexOf(input_text[i][j]) == -1)
                    {
                        MessageBox.Show("Некоторых символов, использованных в исходном тексте, нет в алфавите", "Ошибка",
                            MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }

                if (ab.Length != key.Length)
                {
                    MessageBox.Show("Длина алфавита и длина ключа не совпадает", "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[input_text.Length];

                for (int i = 0; i < input_text.Length; i++)
                {
                    string newline = "";
                    foreach (char sym in input_text[i])
                        newline += key[ab.IndexOf(sym)];
                    output_text[i] = newline;
                }
                return output_text;
            }

            public string[] block_enc()
            {
                //проверка на значение ключа

                System.Int32 a;
                if (!Int32.TryParse(key, out a))
                {
                    MessageBox.Show("Для правильной работы этого алгоритма ключ должен быть числовым значением",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }


                string[] output_text = new string[input_text.Length];
                int i, j;

                //парсим ключ
                for (i = 1; i <= key.Length; i++)
                    if (!key.Contains(Convert.ToString(i)))
                    {
                        MessageBox.Show("Ключ некорректен.", "Ошибка", MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }

                int block_size = key.Length;
                int[] block_order = new int[block_size];
                for (i = 0; i < block_size; i++)
                    block_order[i] = (int) Char.GetNumericValue(key[i]);

                //конвертируем весь текст в одну строку

                string tmp_str_input_text = "";

                for (i = 0; i < input_text.Length; i++)
                    tmp_str_input_text += input_text[i];

                int tail_l = tmp_str_input_text.Length % block_size;
                int enc_part_l = tmp_str_input_text.Length - tail_l;

                char[] str_input_text = new char[enc_part_l];
                char[] tail = new char[tail_l];

                for (i = 0; i < tmp_str_input_text.Length; i++)
                    if (i < enc_part_l)
                        str_input_text[i] = tmp_str_input_text[i];
                    else
                        tail[i - enc_part_l] = tmp_str_input_text[i];

                //основной алгоритм

                for (i = 0; i < str_input_text.Length; i += block_size)
                {
                    char[] block = new char[block_size]; //массив под текущий блок
                    char[] temp_block = new char[block_size];

                    for (j = i; j < i + block_size; j++)
                        block[j - i] = str_input_text[j];

                    for (j = i; j < i + block_size; j++)
                        temp_block[j - i] = str_input_text[j];

                    for (j = 0; j < block_size; j++)
                        block[j] = temp_block[block_order[j] - 1];

                    output_text[0] += new string(block);
                }
                output_text[0] += new string(tail);
                return output_text;
            }

            public string[] hard_block_enc()
            {
                //проверка на значение ключа

                System.Int32 a;
                if (!Int32.TryParse(key, out a))
                {
                    MessageBox.Show(
                        "Для правильной работы этого алгоритма ключ должен быть числовым значением, не превышающим 9",
                        "Ошибка", MessageBoxButtons.OK);
                    string[] answer = new string[1];
                    answer[0] = "";
                    return answer;
                }

                string[] output_text = new string[64];
                int i, j;

                //парсим ключ

                for (i = 1; i <= key.Length; i++)
                    if (!key.Contains(Convert.ToString(i)))
                    {
                        MessageBox.Show("Ключ некорректен.", "Ошибка", MessageBoxButtons.OK);
                        string[] answer = new string[1];
                        answer[0] = "";
                        return answer;
                    }
                int block_size = key.Length;
                int[] block_order = new int[block_size];
                for (i = 0; i < block_size; i++)
                    block_order[i] = (int) Char.GetNumericValue(key[i]);

                //конвертируем весь текст в одну строку

                string tmp_str_input_text = null;

                for (i = 0; i < input_text.Length; i++)
                    tmp_str_input_text += input_text[i];

                int tail_l = tmp_str_input_text.Length % block_size;
                int enc_part_l = tmp_str_input_text.Length - tail_l;

                char[] str_input_text = new char[enc_part_l];
                char[] tail = new char[tail_l];

                for (i = 0; i < tmp_str_input_text.Length; i++)
                    if (i < enc_part_l)
                        str_input_text[i] = tmp_str_input_text[i];
                    else
                        tail[i - enc_part_l] = tmp_str_input_text[i];

                //основной алгоритм

                int k = 0;

                for (i = 0; i < str_input_text.Length; i += block_size)
                {
                    char[] block = new char[block_size]; //массив под текущий блок
                    char[] temp_block = new char[block_size];

                    //   for (j = i; j < i + block_size; j++)
                    //       block[j - i] = str_input_text[j];

                    for (j = i; j < i + block_size; j++)
                        temp_block[j - i] = str_input_text[j];

                    for (j = 0; j < block_size; j++)
                        block[j] = temp_block[block_order[j] - 1];

                    if (k % 2 != 0) Array.Reverse(block);
                    //output_text[k] = new string(block);
                    output_text[0] += new string(block);

                    k++;
                }

                if (k % 2 != 0) Array.Reverse(tail);
                output_text[0] += new string(tail);

                //output_text[k] = new string(tail);
                return output_text;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void load_text_from_file_Click(object sender, EventArgs e)
        {
            string filepath = Interaction.InputBox("Загрузка исходного текста из файла", "Файл:", "");
            if (filepath != "")
                input_text.Lines = File.ReadAllLines(filepath);
        }

        private void load_ab_from_file_Click(object sender, EventArgs e)
        {
            string filepath = Interaction.InputBox("Загрузка алфавита из файла", "Файл:", "");
            if (filepath != "" && File.ReadAllLines(filepath).Count() == 1)
                ab.Lines = File.ReadAllLines(filepath);
        }

        private void load_key_from_file_Click(object sender, EventArgs e)
        {
            string filepath = Interaction.InputBox("Загрузка ключа из файла", "Файл:", "");
            if (filepath != "" && File.ReadAllLines(filepath).Count() == 1)
                key.Lines = File.ReadAllLines(filepath);
        }

        private void encrypt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < input_text.Lines.Length; i++)
                input_text.Lines[i] = input_text.Lines[i].ToLower(); //все в нижний регистр, чтоб не вылетало
            enc ENC = new enc(ab.Text.ToLower(), key.Text.ToLower(), input_text.Lines);
            if (input_text.Text != "" && ab.Text != "" && key.Text != "")
                switch (method.SelectedIndex)
                {
                    case 0:
                        encrypted_text.Lines = ENC.replace();
                        break;

                    case 1:
                        encrypted_text.Lines = ENC.block_enc();
                        break;

                    case 2:
                        encrypted_text.Lines = ENC.hard_block_enc();
                        break;
                    case 3:
                        encrypted_text.Lines = ENC.cesar();
                        break;
                    case 4:
                        encrypted_text.Lines = ENC.XOR();
                        break;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // encrypted_text.Lines = input_text.Lines;
            dec dec = new dec(ab.Text.ToLower(), key.Text.ToLower(), encrypted_text.Lines);
            if (encrypted_text.Text != "" && ab.Text != "" && key.Text != "")
                switch (method.SelectedIndex)
                {
                    case 0:
                        input_text.Lines = dec.replace();
                        break;

                    case 1:
                        input_text.Lines = dec.block_enc();
                        break;

                    case 2:
                        input_text.Lines = dec.hard_block_enc();
                        break;
                    case 3:
                        input_text.Lines = dec.cesar();
                        break;
                    case 4:
                        input_text.Lines = dec.XOR();
                        break;
                }
        }

        private void method_SelectedIndexChanged(object sender, EventArgs e)
        {
            //encrypted_text.Text = "";
            if (
                method.SelectedIndex == 1 || //блок
                method.SelectedIndex == 2 || //усл блок
                method.SelectedIndex == 4 //XOR
            ) ab.Enabled = false;
            else ab.Enabled = true;

            if (method.SelectedIndex == 0)
                key.Text = "zyxwvutsrqponmlkjihgfedcba";
            else
                key.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void encrypted_text_TextChanged(object sender, EventArgs e)
        {
        }

        private void ab_TextChanged(object sender, EventArgs e)
        {
        }
    }
}