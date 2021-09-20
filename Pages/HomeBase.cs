using Metropolitan.Models;
using Metropolitan.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Metropolitan.Pages
{
    public class HomeBase:ComponentBase
    {
        [Inject]
        public IMetropolitanClient _client { get; set; }

        public GetObjectsResponse itemsList;
        public GetObjectResponse item;
        protected bool showDetails = false;
        Timer aTimer;
        private string Time { get; set; }
        protected override async Task OnInitializedAsync()
        {
            itemsList = await _client.getObjects(new GetObjectsRequest
            {
                departmentIds = 1,
                metadataDate = "2021-02-01"
            });

            aTimer = new Timer((_) =>
            {
                InvokeAsync(async () =>
                {
                    await OnTimedEvent();
                    StateHasChanged();
                });
            }, null, 0, 10000);

        }

        private async Task OnTimedEvent()
        {
            Random rand = new Random();
            int toSkip = rand.Next(0, itemsList.objectIDs.Length);
            int randomId = itemsList.objectIDs.Skip(toSkip).Take(1).First();
            
            item = await _client.getObjectDetails(randomId);
        }

        protected void OnImageClicked()
        {
            aTimer.Dispose();
            showDetails = true;
        }


    }
}
