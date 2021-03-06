﻿namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Queries;
    using KudosSlackbot.Data.Services;
    using KudosSlackbot.Data.Services.Validators;

    using MediatR;

    using Slack.Common;

    public class ListKudosQueryHandler : IRequestHandler<ListKudosQuery, ISlackResponseMessage>
    {
        private readonly IKudoService kudoService;

        public ListKudosQueryHandler(IKudoService kudoService)
        {
            this.kudoService = kudoService;
        }

        public Task<ISlackResponseMessage> Handle(ListKudosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                KudoSlashCommandValidatorFactory<ListKudosQuery>.GetValidator().Validate(request);

                var kudo = new Domain.Model.Kudo
                {
                    ByUserId = request.UserId,
                    CommandText = request.Text
                };

                return Task.FromResult(kudoService.GetNKudosByUserId(kudo));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
