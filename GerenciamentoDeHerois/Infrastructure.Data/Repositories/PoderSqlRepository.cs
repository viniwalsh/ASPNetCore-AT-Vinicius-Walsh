using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Context;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;

namespace Infrastructure.Data.Repositories
{
    public class PoderSqlRepository : IPoderRepository
    {
        private readonly IAdoNetScopedContext _adoNetScopedContext;

        public PoderSqlRepository(
            IAdoNetScopedContext adoNetScopedContext)
        {
            _adoNetScopedContext = adoNetScopedContext;
        }

        public async Task<IEnumerable<PoderModel>> GetAllAsync()
        {
            const string commandText =
                "SELECT Id, Poder, Descricao, HeroiId FROM Poder";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            var reader = await sqlCommand.ExecuteReaderAsync();

            var idColumnIndex = reader.GetOrdinal("Id");
            var poderColumnIndex = reader.GetOrdinal("Poder");
            var descricaoColumnIndex = reader.GetOrdinal("Descricao");
            var heroiIdColumnIndex = reader.GetOrdinal("HeroiId");

            var herois = new List<PoderModel>();
            while (await reader.ReadAsync())
            {
                var id = await reader.GetFieldValueAsync<int>(idColumnIndex);
                var poder = await reader.GetFieldValueAsync<string>(poderColumnIndex);
                var descricao = await reader.GetFieldValueAsync<string>(descricaoColumnIndex);
                var heroiId = await reader.GetFieldValueAsync<int>(heroiIdColumnIndex);
                var heroiModel = new PoderModel
                {
                    Id = id,
                    Poder = poder,
                    Descricao = descricao,
                    HeroiId = heroiId
                };
                herois.Add(heroiModel);
            }
            return herois;
        }

        public async Task<PoderModel> GetByIdAsync(int id)
        {
            const string commandText =
                "SELECT Id, Poder, Descricao, HeroiId FROM Poder WHERE Id = @id;";

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

            var heroi = new PoderModel
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                Poder = await reader.GetFieldValueAsync<string>(1),
                Descricao = await reader.GetFieldValueAsync<string>(2),
                HeroiId = await reader.GetFieldValueAsync<int>(3),
            };
            return heroi;
        }

        public async Task<int> AddAsync(
            PoderModel poderModel)
        {
             const string commandText =
                @"INSERT INTO Poder
	                (Poder, Descricao, HeroiId)
                    OUTPUT INSERTED.Id
	                VALUES (@poder, @descricao, @heroiId);";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@poder", SqlDbType.NVarChar)
                .Value = poderModel.Poder;
            sqlCommand.Parameters
                .Add("@descricao", SqlDbType.NVarChar)
                .Value = poderModel.Descricao;
            sqlCommand.Parameters
                .Add("@heroiId", SqlDbType.Int)
                .Value = poderModel.HeroiId;

            var outputId = (int)await sqlCommand.ExecuteScalarAsync();

            return outputId;
        }

        public async Task EditAsync(PoderModel poderModel)
        {
            const string commandText =
            @"UPDATE Poder
	            SET Poder = @poder, Descricao = @descricao, HeroiId = @heroiId
	            WHERE Id = @id;";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@poder", SqlDbType.NVarChar)
                .Value = poderModel.Poder;
            sqlCommand.Parameters
                .Add("@descricao", SqlDbType.NVarChar)
                .Value = poderModel.Descricao;
            sqlCommand.Parameters
                .Add("@heroiId", SqlDbType.DateTime2)
                .Value = poderModel.HeroiId;
            sqlCommand.Parameters
                .Add("@id", SqlDbType.Int)
                .Value = poderModel.Id;

            await sqlCommand.ExecuteScalarAsync();
        }

        public async Task RemoveAsync(PoderModel poderModel)
        {
            const string commandText = "DELETE FROM Poder WHERE Id = @id";

            var sqlCommand = _adoNetScopedContext.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = commandText;

            sqlCommand.Parameters
                .Add("@id", SqlDbType.Int)
                .Value = poderModel.Id;

            await sqlCommand.ExecuteScalarAsync();
        }
    }
}
