﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Vendedor
    {
        [Key]
        public  int idVendedor { get; set; }
        public  string nomeVendedor { get; set; }
    }
}