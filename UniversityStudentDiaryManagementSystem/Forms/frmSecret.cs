﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityStudentDiaryManagementSystem.BL;
using UniversityStudentDiaryManagementSystem.DL;

namespace UniversityStudentDiaryManagementSystem
{
    public partial class frmSecret : Form
    {
        private int selectedIndex;

        public frmSecret(int selectedIndex)
        {
            InitializeComponent();
            this.selectedIndex = selectedIndex;
        }

        private void frmSecret_Load(object sender, EventArgs e)
        {
            if (selectedIndex == 0)
            {
                cmbxType.SelectedIndex = 0;
            }
            else if (selectedIndex == 1)
            {
                cmbxType.SelectedIndex = 1;
            }
            else if (selectedIndex == 2)
            {
                cmbxType.SelectedIndex = 2;
            }
            else if (selectedIndex == 3)
            {
                cmbxType.SelectedIndex = 3;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void clearFields()
        {
            cmbxType.SelectedIndex = 0;
            rctxtbxComment.Clear();
            cmbxType.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbxType.SelectedIndex != 0)
            {
                if (rctxtbxComment.Text != String.Empty)
                {
                    string typeSecret = cmbxType.SelectedItem.ToString();
                    string detail = rctxtbxComment.Text;
                    Secret secret = new Secret(typeSecret, detail);
                    if (SecretDL.setIntoSecretList(secret))
                    {
                        MessageBox.Show("Data Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show("Error while storing data ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Please write something", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rctxtbxComment.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select the type ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbxType.Focus();
            }
        }
    }
}
