using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using JFESM.API;
using JFESM.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JFESM.Web.WebSockets {
    public class RoomHandler : WebSocketHandler {
        private readonly ISalaService salaService;
        public RoomHandler (WebSocketConnectionManager webSocketConnectionManager, ISalaService salaService) : base (webSocketConnectionManager) {
            this.salaService = salaService;
        }
        public override async Task ReceiveAsync (WebSocket socket, WebSocketReceiveResult result, byte[] buffer) {
            string message = Encoding.UTF8.GetString (buffer, 0, result.Count);
            var comandPayload = message.Split ("|");
            if (comandPayload.Count () == 2) {
                if (comandPayload[0].Contains ("pronto")) {
                    salaService.SetReady(WebSocketConnectionManager.GetId(socket));
                    await GetPlayers();
                } else {
                    await SendMessageToAllAsync (message);
                }
            }
        }

        public override async Task OnConnected (HttpContext context, WebSocket socket) {
            string name = "Nome";
            if (!string.IsNullOrEmpty (name) && salaService.GetPlayers ().Count < 6) {
                WebSocketConnectionManager.AddSocket (socket);
                var jogador = salaService.AdicionarJogador (WebSocketConnectionManager.GetId (socket), name);
                await SendMessageAsync ( WebSocketConnectionManager.GetId (socket), JsonConvert.SerializeObject (jogador.ToJogadorViewItem()));
                // await GetPlayers();
            }
        }
        private async Task GetPlayers () {
            await SendMessageToAllAsync (JsonConvert.SerializeObject (salaService.GetPlayers ().ToPlayersViewItems ()));
        }
    }
}