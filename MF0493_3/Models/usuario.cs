//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MF0493_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Empresas = new HashSet<Empresa>();
        }
    
        public string username { get; set; }
        public string email { get; set; }
        public string passwd { get; set; }
        public bool activo { get; set; }
        public Nullable<System.DateTime> lastlogin { get; set; }
    
        public virtual ICollection<Empresa> Empresas { get; set; }

        public bool validar(string passwd)
        {
            string cifrada = this.GetMD5(passwd);

            return cifrada.Equals(this.passwd);
        }
        public string passwdSinCifrar
        {
            set
            {
                this.passwd = this.GetMD5(value);
            }
        }
        private string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}