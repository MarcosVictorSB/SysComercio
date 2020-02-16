using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Dados
{
    class DCategoria
    {
        private int _Idcategoria;
        private string _Nome;
        private string _Descricao;
        private string _Texto;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Texto { get => _Texto; set => _Texto = value; }


        // Construtor Vazio
        public DCategoria() { }

        // Contrutor com paramentros
        public DCategoria(int idcategoria, string nome, string descricao, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Texto = textobuscar;
        }

        //Metodo Inserir
        public string Inserir(DCategoria categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCategoria);


                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 250;
                ParDescricao.Value = categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);


                // executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK": "Registro não foi inserido";
            }
            catch(Exception ex)
            {
                resp = ex.Message;

            }
            finally
            {
               if(SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Metodo Edtiar
        public string Editar(DCategoria categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);


                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 250;
                ParDescricao.Value = categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);


                // executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não foi feita";
            }
            catch (Exception ex)
            {
                resp = ex.Message;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Metodo Excluir
        public string Excluir(DCategoria categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                // executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusao não foi feita";
            }
            catch (Exception ex)
            {
                resp = ex.Message;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Metodo Mostrar
        public DataTable Mostrar(DCategoria categoria)
        {
            DataTable dtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch(Exception ex)
            {
                dtResultado = null;
            }
        }

        //Metodo Inserir
        public DataTable BuscarNome(DCategoria categoria)
        {
            DataTable dtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(dtResultado);

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParTextoBuscar);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

        }
    }
}
