﻿namespace KudosSlackbot.Data.Services
{
    using System;

    using KudosSlackbot.Domain.Model;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public interface IKudoService
    {
        ISlashCommandResponse CreateKudo(Kudo kudo);

        ISlashCommandResponse BuildHelpResponse();

        ISlashCommandResponse GetNKudosByUserId(Kudo kudo);

        ISlashCommandResponse GetAllUserKudos(string userId);

        ISlashCommandResponse DeleteKudo(Guid kudoId);
    }
}
