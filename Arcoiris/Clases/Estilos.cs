using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Arcoiris.Clases
{
   public static class Estilos
    {

        /* =========================
           FONDOS
        ========================= */
        public static Color Background = Color.FromArgb(245, 247, 250);
        public static Color Panel = Color.White;

        /* =========================
           MENÚ SUPERIOR / LATERAL
        ========================= */
        public static Color MenuBackground = Color.FromArgb(30, 58, 95);
        public static Color MenuText = Color.White;
        public static Color MenuActive = Color.FromArgb(47, 128, 237);
        public static Color MenuHover = Color.FromArgb(234, 242, 255);

        /* =========================
           TEXTO
        ========================= */
        public static Color TitleText = Color.FromArgb(31, 41, 51);
        public static Color LabelText = Color.FromArgb(75, 85, 99);
        public static Color SecondaryText = Color.FromArgb(107, 114, 128);
        public static Color DisabledText = Color.FromArgb(156, 163, 175);

        /* =========================
           INPUTS
        ========================= */
        public static Color InputBorder = Color.FromArgb(209, 213, 219);
        public static Color InputText = Color.FromArgb(17, 24, 39);
        public static Color InputFocus = Color.FromArgb(47, 128, 237);
        public static Color InputError = Color.FromArgb(220, 38, 38);
        public static Color InputErrorBackground = Color.FromArgb(254, 226, 226);

        /* =========================
           BOTONES
        ========================= */
        public static Color PrimaryButton = Color.FromArgb(47, 128, 237);
        public static Color PrimaryButtonHover = Color.FromArgb(28, 110, 213);

        public static Color SecondaryButton = Color.FromArgb(229, 231, 235);
        public static Color SecondaryButtonHover = Color.FromArgb(209, 213, 219);

        public static Color DangerButton = Color.FromArgb(220, 38, 38);
        public static Color DangerButtonHover = Color.FromArgb(185, 28, 28);

        /* =========================
           ESTADOS FINANCIEROS
        ========================= */
        public static Color Approved = Color.FromArgb(22, 163, 74);
        public static Color Pending = Color.FromArgb(245, 158, 11);
        public static Color Rejected = Color.FromArgb(220, 38, 38);
        public static Color Overdue = Color.FromArgb(147, 51, 234);

        /* =========================
           ACENTO
        ========================= */
        public static Color Accent = Color.FromArgb(250, 204, 21);

        /* =========================
           MÉTODOS DE APLICACIÓN
        ========================= */

        public static void StyleForm(Form form)
        {
            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 9F);
        }

        public static void StylePrimaryButton(Button btn)
        {
            btn.BackColor = PrimaryButton;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = SecondaryButton;
            btn.ForeColor = TitleText;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void StyleDangerButton(Button btn)
        {
            btn.BackColor = DangerButton;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

    }
}






