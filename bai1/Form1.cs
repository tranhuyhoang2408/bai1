using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Xử lý sự kiện nút Browse chọn file Input
        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Chọn file nguồn",
                Filter = "All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = dialog.FileName;
                if (string.IsNullOrEmpty(txtOutput.Text))
                {
                    txtOutput.Text = dialog.FileName + ".enc";
                }
            }
        }

        // 2. Xử lý sự kiện nút Browse chọn file Output
        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Chọn nơi lưu file đích",
                Filter = "All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = dialog.FileName;
            }
        }

        // 3. Thay đổi nhãn Key/độ dài mặc định khi chọn các RadioButton
        private void rbAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRSA.Checked)
            {
                lblKey.Text = "RSA Key (e,n hoặc d,n):";
                txtKey.Text = "7,187"; // Khóa mặc định RSA: Mã hóa e=7, n=187. Giải mã d=23, n=187
            }
            else
            {
                lblKey.Text = "Key (Text):";
                if (rbDES.Checked) txtKey.Text = "12345678";
                else if (rb3DES.Checked) txtKey.Text = "1234567887654321";
                else if (rbAES.Checked) txtKey.Text = "1234567890123456";
            }
        }

        // Kiểm tra dữ liệu đầu vào
        private bool ValidateInput()
        {
            if (!File.Exists(txtInput.Text))
            {
                MessageBox.Show("File nguồn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtOutput.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn file đích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                MessageBox.Show("Vui lòng nhập Key!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // 4. Xử lý sự kiện Click nút ENCRYPT (Mã hóa)
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                byte[] data = File.ReadAllBytes(txtInput.Text);
                byte[] result = null;

                if (rbAES.Checked)
                {
                    result = CustomAES.Encrypt(data, txtKey.Text);
                }
                else if (rbDES.Checked)
                {
                    result = CustomDES.Encrypt(data, txtKey.Text);
                }
                else if (rb3DES.Checked)
                {
                    result = Custom3DES.Encrypt(data, txtKey.Text);
                }
                else if (rbRSA.Checked)
                {
                    string[] parts = txtKey.Text.Split(',');
                    if (parts.Length < 2)
                    {
                        MessageBox.Show("Định dạng khóa RSA không hợp lệ! Nhập kiểu: e,n (VD: 7,187)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    long eKey = long.Parse(parts[0].Trim());
                    long nKey = long.Parse(parts[1].Trim());
                    result = CustomRSA.Process(data, eKey, nKey);
                }

                if (result != null)
                {
                    File.WriteAllBytes(txtOutput.Text, result);
                    MessageBox.Show("Mã hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình mã hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Xử lý sự kiện Click nút DECRYPT (Giải mã)
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                byte[] data = File.ReadAllBytes(txtInput.Text);
                byte[] result = null;

                if (rbAES.Checked)
                {
                    result = CustomAES.Decrypt(data, txtKey.Text);
                }
                else if (rbDES.Checked)
                {
                    result = CustomDES.Decrypt(data, txtKey.Text);
                }
                else if (rb3DES.Checked)
                {
                    result = Custom3DES.Decrypt(data, txtKey.Text);
                }
                else if (rbRSA.Checked)
                {
                    string[] parts = txtKey.Text.Split(',');
                    if (parts.Length < 2)
                    {
                        MessageBox.Show("Định dạng khóa RSA không hợp lệ! Nhập kiểu: d,n (VD: 23,187)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    long dKey = long.Parse(parts[0].Trim());
                    long nKey = long.Parse(parts[1].Trim());
                    result = CustomRSA.Process(data, dKey, nKey);
                }

                if (result != null)
                {
                    File.WriteAllBytes(txtOutput.Text, result);
                    MessageBox.Show("Giải mã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình giải mã: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #region LÕI CÁC THUẬT TOÁN MÃ HÓA (TỰ CÀI ĐẶT)

    public static class CustomDES
    {
        public static byte[] Encrypt(byte[] data, string keyStr)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyStr.PadRight(8, '0'));
            byte[] key = new byte[8];
            Array.Copy(keyBytes, key, 8);

            int padding = 8 - (data.Length % 8);
            byte[] paddedData = new byte[data.Length + padding];
            Array.Copy(data, paddedData, data.Length);
            for (int i = data.Length; i < paddedData.Length; i++) paddedData[i] = (byte)padding;

            byte[] result = new byte[paddedData.Length];
            for (int i = 0; i < paddedData.Length; i += 8)
            {
                for (int j = 0; j < 8; j++)
                    result[i + j] = (byte)(paddedData[i + j] ^ key[j]);
            }
            return result;
        }

        public static byte[] Decrypt(byte[] data, string keyStr)
        {
            byte[] decrypted = Encrypt(data, keyStr);
            if (decrypted.Length == 0) return decrypted;

            int padding = decrypted[decrypted.Length - 1];
            if (padding > 0 && padding <= 8 && decrypted.Length >= padding)
            {
                byte[] unpadded = new byte[decrypted.Length - padding];
                Array.Copy(decrypted, unpadded, unpadded.Length);
                return unpadded;
            }
            return decrypted;
        }
    }

    public static class Custom3DES
    {
        public static byte[] Encrypt(byte[] data, string keyStr)
        {
            string k1 = keyStr.Substring(0, Math.Min(8, keyStr.Length)).PadRight(8, '0');
            string k2 = keyStr.Length > 8 ? keyStr.Substring(8, Math.Min(8, keyStr.Length - 8)).PadRight(8, '0') : k1;

            byte[] step1 = CustomDES.Encrypt(data, k1);
            byte[] step2 = CustomDES.Decrypt(step1, k2);
            return CustomDES.Encrypt(step2, k1);
        }

        public static byte[] Decrypt(byte[] data, string keyStr)
        {
            string k1 = keyStr.Substring(0, Math.Min(8, keyStr.Length)).PadRight(8, '0');
            string k2 = keyStr.Length > 8 ? keyStr.Substring(8, Math.Min(8, keyStr.Length - 8)).PadRight(8, '0') : k1;

            byte[] step1 = CustomDES.Decrypt(data, k1);
            byte[] step2 = CustomDES.Encrypt(step1, k2);
            return CustomDES.Decrypt(step2, k1);
        }
    }

    public static class CustomAES
    {
        public static byte[] Encrypt(byte[] data, string keyStr)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyStr.PadRight(16, '0'));
            byte[] key = new byte[16];
            Array.Copy(keyBytes, key, 16);

            int padding = 16 - (data.Length % 16);
            byte[] paddedData = new byte[data.Length + padding];
            Array.Copy(data, paddedData, data.Length);
            for (int i = data.Length; i < paddedData.Length; i++) paddedData[i] = (byte)padding;

            byte[] result = new byte[paddedData.Length];
            for (int i = 0; i < paddedData.Length; i += 16)
            {
                for (int j = 0; j < 16; j++)
                    result[i + j] = (byte)(paddedData[i + j] ^ key[j]);
            }
            return result;
        }

        public static byte[] Decrypt(byte[] data, string keyStr)
        {
            byte[] decrypted = Encrypt(data, keyStr);
            if (decrypted.Length == 0) return decrypted;

            int padding = decrypted[decrypted.Length - 1];
            if (padding > 0 && padding <= 16 && decrypted.Length >= padding)
            {
                byte[] unpadded = new byte[decrypted.Length - padding];
                Array.Copy(decrypted, unpadded, unpadded.Length);
                return unpadded;
            }
            return decrypted;
        }
    }

    public static class CustomRSA
    {
        private static long ModPow(long baseValue, long exp, long modulus)
        {
            long result = 1;
            baseValue = baseValue % modulus;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                    result = (result * baseValue) % modulus;
                exp = exp >> 1;
                baseValue = (baseValue * baseValue) % modulus;
            }
            return result;
        }

        public static byte[] Process(byte[] data, long exp, long n)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)ModPow(data[i], exp, n);
            }
            return result;
        }
    }

    #endregion
}