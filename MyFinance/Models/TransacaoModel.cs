﻿using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public bool Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Conta_Id { get; set; }
        public int Plano_Contas_Id { get; set; }
        public string NomeConta { get; set; }
        public string DescricaoPlano { get; set; }


        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<TransacaoModel> ListaPLanoConta()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            string sql = "SELECT t.Id, t.Data,t.Tipo, t.Valor, t.Descricao as historico,t.Conta_Id, " +
                          "c.Nome as conta, t.Plano_Contas_Id, p.Descricao as plano_conta " +
                          "FROM transacao as t inner join conta c on t.Conta_Id = c.Id inner join plano_contas as p " +
                          $"on t.Plano_Contas_Id = p.Id where t.Usuario_Id = {usuarioLogado} order by t.data desc limit 10";

            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.Id = int.Parse(dataTable.Rows[i]["Id"].ToString());
                item.Data = DateTime.Parse(dataTable.Rows[i]["Data"].ToString()).ToString("dd/MM/yyyy");
                item.Tipo = Convert.ToBoolean(dataTable.Rows[i]["Tipo"].ToString());
                item.Valor = Decimal.Parse(dataTable.Rows[i]["Valor"].ToString());
                item.Descricao = dataTable.Rows[i]["historico"].ToString();
                item.Conta_Id = int.Parse(dataTable.Rows[i]["Conta_Id"].ToString());
                item.NomeConta = dataTable.Rows[i]["conta"].ToString();
                item.Plano_Contas_Id = int.Parse(dataTable.Rows[i]["Plano_Contas_Id"].ToString());
                item.DescricaoPlano = dataTable.Rows[i]["plano_conta"].ToString();
                lista.Add(item);
            }

            return lista;
        }

        public void InsertUpdate(string usuarioLogado)
        {
            string sql = "";

            if (Id != 0)
            {
                sql = $"UPDATE transacao SET Data='{Data}', Tipo = '{Tipo}', Valor = '{Valor}', Descricao = '{Descricao}' WHERE Usuario_Id = '{usuarioLogado}' AND Id = '{Id}'";
            }
            else
            {
                sql = $"INSERT INTO transacao (Data, Tipo, Valor, Descricao, Conta_Id, Plano_Contas_Id) VALUES ('{Data}','{Tipo}','{Valor}','{Descricao}','{Conta_Id}','{Plano_Contas_Id}')";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

        public void ExcluirConta(string id)
        {
            string sql = "DELETE FROM transacao WHERE Id = " + id;
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
        }

    }
}