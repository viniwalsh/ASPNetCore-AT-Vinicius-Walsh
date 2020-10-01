using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Context;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;

namespace Infrastructure.Data.Repositories
{
    public class HeroiSqlRepository : IHeroiRepository
    {
        private readonly IAdoNetScopedContext _adoNetScopedContext;

        public HeroiSqlRepository(
            IAdoNetScopedContext adoNetScopedContext)
        {
            _adoNetScopedContext = adoNetScopedContext;
        }

        public async Task<IEnumerable<HeroiModel>> GetAllAsync(string search)
        {
            var commandText =
                "SELECT Id, NomeCompleto, Codinome, Lancamento, ImageURL FROM Heroi";

            var searchHasValue = !string.IsNullOrWhiteSpace(search);
            if (searchHasValue)
            {
                commandText += " WHERE NomeCompleto LIKE @search OR Codinome Like @search";
            }

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            if (searchHasValue)
            {
                sqlCommand.Parameters
                    .Add("@search", SqlDbType.NVarChar)
                    .Value = $"%{search}%";
            }
            var reader = await sqlCommand.ExecuteReaderAsync();

            var idColumnIndex = reader.GetOrdinal("Id");
            var nomeCompletoColumnIndex = reader.GetOrdinal("NomeCompleto");
            var codinomeColumnIndex = reader.GetOrdinal("Codinome");
            var lancamentoColumnIndex = reader.GetOrdinal("Lancamento");
            var imageURLColumnIndex = reader.GetOrdinal("ImageURL");

            var herois = new List<HeroiModel>();
            while (await reader.ReadAsync())
            {
                var id = await reader.GetFieldValueAsync<int>(idColumnIndex);
                var nomeCompleto = await reader.GetFieldValueAsync<string>(nomeCompletoColumnIndex);
                var codinome = await reader.GetFieldValueAsync<string>(codinomeColumnIndex);
                var lancamento = await reader.GetFieldValueAsync<DateTime>(lancamentoColumnIndex);
                var imageURL = await reader.GetFieldValueAsync<string>(imageURLColumnIndex);
                var heroiModel = new HeroiModel
                {
                    Id = id,
                    NomeCompleto = nomeCompleto,
                    Codinome = codinome,
                    Lancamento = lancamento,
                    ImageURL = imageURL
                };
                herois.Add(heroiModel);
            }
            return herois;
        }

        public async Task<HeroiModel> GetByIdAsync(int id)
        {
            const string commandText =
                "SELECT Id, NomeCompleto, Codinome, Lancamento, ImageURL FROM Heroi WHERE Id = @id;";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@id", SqlDbType.Int)
                .Value = id;

            var reader = await sqlCommand.ExecuteReaderAsync();

            var canRead = await reader.ReadAsync();
            if (!canRead)
                return null;

            var heroi = new HeroiModel
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                NomeCompleto = await reader.GetFieldValueAsync<string>(1),
                Codinome = await reader.GetFieldValueAsync<string>(2),
                Lancamento = await reader.GetFieldValueAsync<DateTime>(3),
                ImageURL = await reader.GetFieldValueAsync<string>(4),
            };
            return heroi;
        }

        public async Task<int> AddAsync(
            HeroiModel heroiModel)
        {
            const string commandText =
                    @"INSERT INTO Heroi
	                (NomeCompleto, Codinome, Lancamento, ImageURL)
                    OUTPUT INSERTED.Id
	                VALUES (@nomeCompleto, @codinome, @lancamento, @imageURL);";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@nomeCompleto", SqlDbType.NVarChar)
                .Value = heroiModel.NomeCompleto;
            sqlCommand.Parameters
                .Add("@codinome", SqlDbType.NVarChar)
                .Value = heroiModel.Codinome;
            sqlCommand.Parameters
                .Add("@lancamento", SqlDbType.DateTime2)
                .Value = heroiModel.Lancamento;
            sqlCommand.Parameters
                .Add("@imageURL", SqlDbType.NVarChar)
                .Value = heroiModel.ImageURL;

            var outputId = (int)await sqlCommand.ExecuteScalarAsync();

            return outputId;
        }

        public async Task EditAsync(HeroiModel heroiModel)
        {
            const string commandText =
                            @"UPDATE Heroi
	                SET NomeCompleto = @nomeCompleto, Codinome = @codinome, Lancamento = @lancamento, ImageURL = @imageURL
	                WHERE Id = @id;";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@nomeCompleto", SqlDbType.NVarChar)
                .Value = heroiModel.NomeCompleto;
            sqlCommand.Parameters
                .Add("@codinome", SqlDbType.NVarChar)
                .Value = heroiModel.Codinome;
            sqlCommand.Parameters
                .Add("@lancamento", SqlDbType.DateTime2)
                .Value = heroiModel.Lancamento;
            sqlCommand.Parameters
                .Add("@imageURL", SqlDbType.NVarChar)
                .Value = heroiModel.ImageURL;
            sqlCommand.Parameters
                .Add("@id", SqlDbType.Int)
                .Value = heroiModel.Id;

            await sqlCommand.ExecuteScalarAsync();
        }

        public async Task RemoveAsync(HeroiModel heroiModel)
        {
            const string commandText = "DELETE FROM Heroi WHERE Id = @id";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@id", SqlDbType.Int)
                .Value = heroiModel.Id;

            await sqlCommand.ExecuteScalarAsync();
        }
    }
}
