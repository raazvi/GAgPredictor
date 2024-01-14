namespace GAg_Predictor
{
    partial class SimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.traceTextbox = new System.Windows.Forms.TextBox();
            this.chooseTraceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.liniiTabelParam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HRParam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LRUParam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.predictie1Bit = new System.Windows.Forms.RadioButton();
            this.predictie2Biti = new System.Windows.Forms.RadioButton();
            this.bitiPredictiePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.arhitecturaMD = new System.Windows.Forms.RadioButton();
            this.arhitecturaCA = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.simulateButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.bitiPredictiePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduceti calea spre fisierul sursa ( *.tra): ";
            // 
            // traceTextbox
            // 
            this.traceTextbox.Location = new System.Drawing.Point(16, 32);
            this.traceTextbox.Name = "traceTextbox";
            this.traceTextbox.Size = new System.Drawing.Size(330, 22);
            this.traceTextbox.TabIndex = 1;
            // 
            // chooseTraceButton
            // 
            this.chooseTraceButton.Location = new System.Drawing.Point(371, 30);
            this.chooseTraceButton.Name = "chooseTraceButton";
            this.chooseTraceButton.Size = new System.Drawing.Size(134, 24);
            this.chooseTraceButton.TabIndex = 2;
            this.chooseTraceButton.Text = "Alege Fisier";
            this.chooseTraceButton.UseVisualStyleBackColor = true;
            this.chooseTraceButton.Click += new System.EventHandler(this.chooseTraceButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 107);
            this.label2.TabIndex = 3;
            this.label2.Text = "Introduceti numarul de intrari in tabela: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // liniiTabelParam
            // 
            this.liniiTabelParam.Location = new System.Drawing.Point(16, 167);
            this.liniiTabelParam.Name = "liniiTabelParam";
            this.liniiTabelParam.Size = new System.Drawing.Size(130, 22);
            this.liniiTabelParam.TabIndex = 4;
            this.liniiTabelParam.Text = "256";
            this.liniiTabelParam.TextChanged += new System.EventHandler(this.liniiTabelParam_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 107);
            this.label3.TabIndex = 5;
            this.label3.Text = "Introduceti HR global (biti): ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HRParam
            // 
            this.HRParam.Location = new System.Drawing.Point(195, 167);
            this.HRParam.Name = "HRParam";
            this.HRParam.Size = new System.Drawing.Size(130, 22);
            this.HRParam.TabIndex = 6;
            this.HRParam.Text = "4";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(371, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 107);
            this.label4.TabIndex = 7;
            this.label4.Text = "Introduceti LRU (biti): ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LRUParam
            // 
            this.LRUParam.Location = new System.Drawing.Point(371, 167);
            this.LRUParam.Name = "LRUParam";
            this.LRUParam.Size = new System.Drawing.Size(134, 22);
            this.LRUParam.TabIndex = 8;
            this.LRUParam.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 77);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alegeti tipul de arhitectura:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 77);
            this.label6.TabIndex = 10;
            this.label6.Text = "Alegeti numarul de biti de predictie:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // predictie1Bit
            // 
            this.predictie1Bit.Checked = true;
            this.predictie1Bit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictie1Bit.Location = new System.Drawing.Point(3, 3);
            this.predictie1Bit.Name = "predictie1Bit";
            this.predictie1Bit.Size = new System.Drawing.Size(130, 24);
            this.predictie1Bit.TabIndex = 13;
            this.predictie1Bit.TabStop = true;
            this.predictie1Bit.Text = "1 bit";
            this.predictie1Bit.UseVisualStyleBackColor = true;
            this.predictie1Bit.CheckedChanged += new System.EventHandler(this.predictie1Bit_CheckedChanged);
            // 
            // predictie2Biti
            // 
            this.predictie2Biti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictie2Biti.Location = new System.Drawing.Point(3, 32);
            this.predictie2Biti.Name = "predictie2Biti";
            this.predictie2Biti.Size = new System.Drawing.Size(130, 24);
            this.predictie2Biti.TabIndex = 14;
            this.predictie2Biti.Text = "2 biti";
            this.predictie2Biti.UseVisualStyleBackColor = true;
            this.predictie2Biti.CheckedChanged += new System.EventHandler(this.predictie2Biti_CheckedChanged);
            // 
            // bitiPredictiePanel
            // 
            this.bitiPredictiePanel.Controls.Add(this.predictie2Biti);
            this.bitiPredictiePanel.Controls.Add(this.predictie1Bit);
            this.bitiPredictiePanel.Location = new System.Drawing.Point(195, 400);
            this.bitiPredictiePanel.Name = "bitiPredictiePanel";
            this.bitiPredictiePanel.Size = new System.Drawing.Size(130, 59);
            this.bitiPredictiePanel.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.arhitecturaMD);
            this.panel1.Controls.Add(this.arhitecturaCA);
            this.panel1.Location = new System.Drawing.Point(16, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 59);
            this.panel1.TabIndex = 16;
            // 
            // arhitecturaMD
            // 
            this.arhitecturaMD.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arhitecturaMD.Location = new System.Drawing.Point(3, 32);
            this.arhitecturaMD.Name = "arhitecturaMD";
            this.arhitecturaMD.Size = new System.Drawing.Size(130, 24);
            this.arhitecturaMD.TabIndex = 14;
            this.arhitecturaMD.Text = "Mapat Direct";
            this.arhitecturaMD.UseVisualStyleBackColor = true;
            this.arhitecturaMD.CheckedChanged += new System.EventHandler(this.arhitecturaMD_CheckedChanged);
            // 
            // arhitecturaCA
            // 
            this.arhitecturaCA.Checked = true;
            this.arhitecturaCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arhitecturaCA.Location = new System.Drawing.Point(3, 3);
            this.arhitecturaCA.Name = "arhitecturaCA";
            this.arhitecturaCA.Size = new System.Drawing.Size(130, 24);
            this.arhitecturaCA.TabIndex = 13;
            this.arhitecturaCA.TabStop = true;
            this.arhitecturaCA.Text = "Complet As.";
            this.arhitecturaCA.UseVisualStyleBackColor = true;
            this.arhitecturaCA.CheckedChanged += new System.EventHandler(this.arhitecturaCA_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 90);
            this.label7.TabIndex = 17;
            this.label7.Text = "Valoarea trebuie sa fie o putere de-a lui 2. Minim 2 intrari!";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simulateButton
            // 
            this.simulateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateButton.Location = new System.Drawing.Point(13, 466);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(133, 62);
            this.simulateButton.TabIndex = 18;
            this.simulateButton.Text = "Simuleaza";
            this.simulateButton.UseVisualStyleBackColor = true;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(195, 467);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(130, 61);
            this.resetButton.TabIndex = 19;
            this.resetButton.Text = "Reseteaza Configuratii";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(531, 539);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bitiPredictiePanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LRUParam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HRParam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.liniiTabelParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseTraceButton);
            this.Controls.Add(this.traceTextbox);
            this.Controls.Add(this.label1);
            this.Name = "SimulatorForm";
            this.Text = "Simulator - Date De Intrare";
            this.bitiPredictiePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox traceTextbox;
        private System.Windows.Forms.Button chooseTraceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox liniiTabelParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HRParam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LRUParam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton predictie1Bit;
        private System.Windows.Forms.RadioButton predictie2Biti;
        private System.Windows.Forms.Panel bitiPredictiePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton arhitecturaMD;
        private System.Windows.Forms.RadioButton arhitecturaCA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Button resetButton;
    }
}

