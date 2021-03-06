﻿namespace KudosSlackbot.Data.Services.Validators
{
    using KudosSlackbot.Application.Commands;
    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Domain.Services;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class KudoSlashCommandValidatorFactory<T> : IKudoSlashCommandValidatorFactory where T : IKudoRequest
    {
        // TODO Do this better
        public static IKudoSlashCommandValidator<T> GetValidator()
        {
            var commandType = typeof(T);

            if (commandType == typeof(CreateKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new KudoAddCommandValidator();
            }
            else if (commandType == typeof(ListKudosQuery))
            {
                return (IKudoSlashCommandValidator<T>)new ListKudosQueryValidator();
            }
            else if (commandType == typeof(DeleteKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new DeleteKudoCommandValidator();
            }
            else if (commandType == typeof(ReplaceKudoCommand))
            {
                return (IKudoSlashCommandValidator<T>)new ReplaceKudoCommandValidator();
            }
            else if (commandType == typeof(ListUserKudosQuery))
            {
                return (IKudoSlashCommandValidator<T>)new ListUserKudosQueryValidator();
            }
            else if (commandType == typeof(ListTopUsersQuery))
            {
                return (IKudoSlashCommandValidator<T>)new ListTopUsersQueryValidator();
            }


            throw new System.InvalidOperationException("Unknown Kudo Command.");
        }
    }
}
