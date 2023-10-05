<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs"
  Inherits="SimpleWebSocketApplication.WebForm" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<>
  <form id="form1" runat="server">
    <div>
      <span id="webSocketStatusSpan"></span>
      <br />
      <span id="webSocketReceiveDataSpan"></span>
      <br />
      <span>Введите строку для отправки</span>
      <br />
      <input id="nameTextBox" type="text" value="" />
      <input type="button" value="Отправить данные" onclick="SendData();" />
      <input type="button" value="Закрыть веб-сокет" onclick="CloseWebSocket();" />
    </div>
  </form>
  <script type="text/javascript">
 
    var webSocketStatusSpan = document.getElementById("webSocketStatusSpan");
    var webSocketReceiveDataSpan = document.getElementById("webSocketReceiveDataSpan");
    var nameTextBox = document.getElementById("nameTextBox");
 
    var webSocket;
    //Адрес нашего обработчика HTTP-данных, который будет отвечать на запросы.
    var handlerUrl = "ws://localhost/SimpleWebSocketApplication/WebSocketHandler.ashx";
	var handlerUrl = "ws://localhost/WordEngineering/Yatajga/WebSocketHandler.ashx";
    //Метод отправляющий данные.
    function SendData() {
      //Метод инициализирующий веб-сокет.
      InitWebSocket();
      //Смотрим, если веб-сокет открыт и готов к использованию
      //отправляем данные.
      if (webSocket.OPEN && webSocket.readyState == 1)
        webSocket.send(nameTextBox.value);
      //Если веб-сокет закрывается или закрыт, выводим сообщение.
      if (webSocket.readyState == 2 || webSocket.readyState == 3)
        webSocketStatusSpan.innerText = "Веб-сокет закрыт, отправить данные невозможно."
    }
    function CloseWebSocket() {
      //Функция для программного закрытия веб-сокета.
      //После закрытия, получать или отправлять данные не получится.
      webSocket.close();
    }
    function InitWebSocket() {
      //Если объект веб-сокета не инициализирован, инициализируем его.
      if (webSocket == undefined) {
        webSocket = new WebSocket(handlerUrl);
 
        //Устанавливаем обработчик открытия соединения.
        webSocket.onopen = function () {
          webSocketStatusSpan.innerText = "Веб-сокет окрыт."
          webSocket.send(nameTextBox.value);
        };
 
        //Устанавливаем обработчик получения данных.
        webSocket.onmessage = function (e) {
          webSocketReceiveDataSpan.innerText = e.data;
        };
 
        //Устанавливаем обработчик закрытия соединения.
        webSocket.onclose = function () {
          webSocketStatusSpan.innerText = "Веб-сокет закрыт."
        };
 
        //Устанавливаем обработчик ошибки.
        webSocket.onerror = function (e) {
          webSocketStatusSpan.innerText = e.message;
        }
      }
    }
 
  </script>
</>
</html>

//Конечной точкой, обрабатывающей запрос по протоколу WebSocket, на стороне сервера будет обработчик HTTP-данных. Добавим его в наше приложение, а после следующий код.

using System;
using System.Web;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
 
using System.Net.WebSockets;
using System.Web.WebSockets;
 
namespace Yatajga
{
  public class WebSocketHandler : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      //Проверяем, является ли запрос, запросом по протоколу WebSocket.
      if (context.IsWebSocketRequest)
      {
        //Если да, назначаем асинхронный обработчик.
        context.AcceptWebSocketRequest(WebSocketRequestHandler);
      }
    }
 
    public bool IsReusable { get { return false; } }
 
    //Асинхронный обработчик запроса.
    public async Task WebSocketRequestHandler(AspNetWebSocketContext webSocketContext)
    {
      //Получаем текущий объект веб-сокета.
      WebSocket webSocket = webSocketContext.WebSocket;
 
      /*Определяем некую константу, которая будет представлять
      максимльный размер входных данных. Её устанавливаем мы и значение
      можем задать любым. Мы знаем, что в данном случае размер пересылаемых
      данных очень мал.
      */
      const int maxMessageSize = 1024;
 
      //Буфер битов, в который будут записываться полученные данные.
      ArraySegment<Byte> receivedDataBuffer = new ArraySegment<Byte>(new Byte[maxMessageSize]);
 
      //Токен отмены, в данном примере не используется.
      var cancellationToken = new CancellationToken();
 
      //Проверяем состояние веб-сокета.
      while (webSocket.State == WebSocketState.Open)
      {
        //Читаем данные.
        WebSocketReceiveResult webSocketReceiveResult = 
          await webSocket.ReceiveAsync(receivedDataBuffer, cancellationToken);
        //Смотрим, если входной фрейм закрывающий, посылаем ответ на закрытие.
        if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
        {
          await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
            String.Empty, cancellationToken);
        }
        else
        {
          //Читаем только те байты, которые пришли.
          byte[] payloadData = receivedDataBuffer.Array.Where(b => b != 0).ToArray();
          //Поскольку мы знаем, что это строка, то конвертируем.
          string receiveString = 
            System.Text.UTF8Encoding.UTF8.GetString(payloadData, 0, payloadData.Length);
          //Собираем новую строку и преобразовываем в массив байт.
          var newString = 
            String.Format("Hello, " + receiveString + " ! Time {0}", DateTime.Now.ToString());
          Byte[] bytes = System.Text.UTF8Encoding.UTF8.GetBytes(newString);
          //Отсылаем данные обратно браузеру.
          await webSocket.SendAsync(new ArraySegment<byte>(bytes),
            WebSocketMessageType.Text, true, cancellationToken);
        }
      }
    }
  }
}
