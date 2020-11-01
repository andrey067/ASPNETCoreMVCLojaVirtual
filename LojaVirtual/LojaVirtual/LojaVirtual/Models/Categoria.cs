using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Categoria
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        /*o que é Slug - é tudo o que vem depois da última “/” no caminho e geralmente identifica o arquivo ou a página da Web
         * exemplo
         * www.lojavirutal.com.br/categoria/5 // URL normal
         * com slug - deixando a url amigavel
         * www.lojavirutal.com.br/categoria/informatica
         */
        public string Slug { get; set; }

        /*Subniveis de categoria, se ultiliza Auto relacionamento
         * Ex:
         * 1-Informatica - Categoria Pai=null
         * 2 -Mouse - P: 1
         * -- 3 mouse sem fio - P: 2
         * -- 4 mouse com fio- P:2
         * -- 5 mouse gamer - P:2
         */
        public int? CategoriaPaiID { get; set; }
        
        
        
        /*ORM - Entity FrameWorkCore
         * Para fazer o relaciomento das categorias ultiliza-se o metodo a baixo
         *podendo assim fazer a assoriacao
         */
        [ForeignKey("CategoriaPaiID")] // Vintuclo das tabelas fazendo o auto relaciomento
        public virtual Categoria CategoriaPai { get; set; }

    }
}
