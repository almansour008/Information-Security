using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classical_ciphering;

namespace classical_ciphering
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMessageCaesar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncryptionCaesar_Click(object sender, EventArgs e)
        {
            txtEncryptionCaesar.Text = "";
            CaesarCipher caesar = new CaesarCipher();
            txtEncryptionCaesar.Text = caesar.encryption(txtMessageCaesar.Text, int.Parse(txtKeyCaesar.Text));
        }

        private void btnDecryptionCaesar_Click(object sender, EventArgs e)
        {
            txtDecryptionCaesar.Text = "";
            CaesarCipher caesar = new CaesarCipher();
            txtDecryptionCaesar.Text = caesar.decryption(txtEncryptionCaesar.Text, int.Parse(txtKeyCaesar.Text));
        }

        private void btnClearCaesar_Click(object sender, EventArgs e)
        {
            txtMessageCaesar.Text = "";
            txtKeyCaesar.Text = "";
            txtEncryptionCaesar.Text = "";
            txtDecryptionCaesar.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClearAffine_Click(object sender, EventArgs e)
        {
            txtMessageAffine.Text = "";
            txtFKeyAffine.Text = "";
            txtSKeyAffine.Text = "";
            txtEncryptionAffine.Text = "";
            txtDecryptionAffine.Text = "";
        }

        private void btnEncryptionAffine_Click(object sender, EventArgs e)
        {
            Affine affine = new Affine();
            txtEncryptionAffine.Text = affine.affineEncryption(txtMessageAffine.Text,int.
                Parse(txtFKeyAffine.Text),int.Parse(txtSKeyAffine.Text));

        }

        private void btnDecrytpionAffine_Click(object sender, EventArgs e)
        {
            Affine affine=new Affine();
            txtDecryptionAffine.Text = affine.affineDecryption(txtEncryptionAffine.Text
                , affine.extendedEuclidean(int.
                Parse(txtFKeyAffine.Text), affine.alphabet.Length), int.Parse(txtSKeyAffine.Text));

        }

        private void btnClearHill_Click(object sender, EventArgs e)
        {
            txtMessageHill.Text = "";
            txtKeyMatrix00Hill.Text = "";
            txtKeyMatrix01Hill.Text = "";
            txtKeyMatrix10Hill.Text = "";
            txtKeyMatrix11Hill.Text = "";
            txtEncryptionHill.Text = "";
            txtDecryptionHill.Text = "";
        }

        private void btnEncryptionHill_Click(object sender, EventArgs e)
        {
            int[,] keyHill = { { int.Parse(txtKeyMatrix00Hill.Text), int.Parse(txtKeyMatrix01Hill.Text) },
                            { int.Parse(txtKeyMatrix10Hill.Text), int.Parse(txtKeyMatrix11Hill.Text) }
            };
            Hill hill=new Hill(keyHill);
            txtEncryptionHill.Text = hill.Encrypt(txtMessageHill.Text);
        }

        private void btnDecryptionHill_Click(object sender, EventArgs e)
        {
            int[,] keyHill = { { int.Parse(txtKeyMatrix00Hill.Text), int.Parse(txtKeyMatrix01Hill.Text) },
                            { int.Parse(txtKeyMatrix10Hill.Text), int.Parse(txtKeyMatrix11Hill.Text) }
            };
            Hill hill = new Hill(keyHill);
            txtDecryptionHill.Text = hill.Decrypt(txtEncryptionHill.Text);
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnClearVigenere_Click_1(object sender, EventArgs e)
        {
            txtMessageVigenere.Text = "";
            txtKeyVigenere.Text = "";
            txtEncryptionVigenere.Text = "";
            txtDecryptionVigenere.Text = "";
        }

        private void btnEncryptionVigenere_Click(object sender, EventArgs e)
        {
            Vigenere vigenere = new Vigenere(txtKeyVigenere.Text);
            txtEncryptionVigenere.Text = vigenere.Encrypt(txtMessageVigenere.Text);
        }

        private void btnDecryptionVigenere_Click(object sender, EventArgs e)
        {
            Vigenere vigenere = new Vigenere(txtKeyVigenere.Text);
            txtDecryptionVigenere.Text = vigenere.Decrypt(txtEncryptionVigenere.Text);
        }

        private void btnClearVernam_Click(object sender, EventArgs e)
        {
            txtMessageVernam.Text = "";
            txtKeyVernam.Text = "";
            txtEncryptionVernam.Text = "";
            txtDecryptionVernam.Text = "";
        }

        private void btnEncryptionVernam_Click(object sender, EventArgs e)
        {
            Vernam vernam=new Vernam(txtKeyVernam.Text);
            txtEncryptionVernam.Text=vernam.Encrypt(txtMessageVernam.Text);
        }

        private void btnDecryptionVernam_Click(object sender, EventArgs e)
        {
            Vernam vernam = new Vernam(txtKeyVernam.Text);
            txtDecryptionVernam.Text = vernam.Decrypt(txtEncryptionVernam.Text);
        }

        private void btnClearADFGVX_Click(object sender, EventArgs e)
        {
            txtMessageADFGVX.Text = "";
            txtKeyADFGVX.Text = "";
            txtEncryptionADFGVX.Text = "";
            txtDecryptionADFGVX.Text = "";
        }

        private void btnEncryptionADFGVX_Click(object sender, EventArgs e)
        {
            ADFGVX adfgvx=new ADFGVX(txtKeyADFGVX.Text);
            txtEncryptionADFGVX.Text=adfgvx.Encrypt(txtMessageADFGVX.Text);
        }

        private void btnDecryptionADFGVX_Click(object sender, EventArgs e)
        {
            ADFGVX adfgvx = new ADFGVX(txtKeyADFGVX.Text);
            txtDecryptionADFGVX.Text = adfgvx.Decrypt(txtEncryptionADFGVX.Text);
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void btnClearPlayfair_Click(object sender, EventArgs e)
        {
            txtMessagePlayfair.Text = "";
            txtKeyPlayfair.Text = "";
            txtEncryptionPlayfair.Text = "";
            txtDecryptionPlayfair.Text = "";
        }

        private void btnEncryptionPlayfair_Click(object sender, EventArgs e)
        {
            Playfair playfair=new Playfair(txtKeyPlayfair.Text);
            txtEncryptionPlayfair.Text=playfair.Encrypt(txtMessagePlayfair.Text);
        }

        private void btnDecryptionPlayfair_Click(object sender, EventArgs e)
        {
            Playfair playfair = new Playfair(txtKeyPlayfair.Text);
            txtDecryptionPlayfair.Text = playfair.Decrypt(txtEncryptionPlayfair.Text);
        }

        private void affine_hill_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearAffineHill_Click(object sender, EventArgs e)
        {
            txtMessageAffineHill.Text = "";
            txtKeyMatrix00AffineHill.Text = "";
            txtKeyMatrix01AffineHill.Text = "";
            txtKeyMatrix10AffineHill.Text = "";
            txtKeyMatrix11AffineHill.Text = "";
            txtEncryptionAffineHill.Text = "";
            txtDecryptionAffineHill.Text = "";
        }

        private void btnEncryption_Click(object sender, EventArgs e)
        {
            int[,] keyAffineHill = { { int.Parse(txtKeyMatrix00AffineHill.Text), int.Parse(txtKeyMatrix01AffineHill.Text) },
                            { int.Parse(txtKeyMatrix10AffineHill.Text), int.Parse(txtKeyMatrix11AffineHill.Text) }
            };
            AffineHill affineHill = new AffineHill(keyAffineHill);
            txtEncryptionAffineHill.Text = affineHill.Encrypt(txtMessageAffineHill.Text);
        }

        private void txtDecryptionAffine_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnDecryptionAffineHill_Click(object sender, EventArgs e)
        {
            int[,] keyAffineHill = { { int.Parse(txtKeyMatrix00AffineHill.Text), int.Parse(txtKeyMatrix01AffineHill.Text) },
                            { int.Parse(txtKeyMatrix10AffineHill.Text), int.Parse(txtKeyMatrix11AffineHill.Text) }
            };

            AffineHill affineHill = new AffineHill(keyAffineHill);
            txtDecryptionAffineHill.Text = affineHill.Decrypt(txtEncryptionAffineHill.Text);
        }
    }
}
