    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types.Enums;
    using Telegram.Bot.Types.InlineQueryResults;
    using Telegram.Bot.Types.ReplyMarkups;

    namespace Telegram.Bot.Examples.Echo
    {
        public static class Program
        {
            private static readonly TelegramBotClient Bot = new TelegramBotClient("1066585479:AAFrdNxCQnbQHPbRK_KHZnSSLsLPZmwuQws");

            public static void Main(string[] args)
            {
                var me = Bot.GetMeAsync().Result;
                Console.Title = me.Username;
               
                Bot.OnMessage += Menu;
              

                Bot.StartReceiving(Array.Empty<UpdateType>());
                Console.WriteLine($"Start listening for @{me.Username}");
                Console.ReadLine();
                Bot.StopReceiving();
            }

            private static async void Menu(object sender, MessageEventArgs eventArgs)
            {
                var message = eventArgs.Message;
                if (message == null || message.Type != MessageType.Text) return;
               
                var keyborad = new InlineKeyboardMarkup(new[]
                     {
                            new [] 
                            {
                                InlineKeyboardButton.WithCallbackData("Абитуриент","Абитуриент"),
                                InlineKeyboardButton.WithCallbackData("Бакалавриат","Бакалавриат")
                            },
                            new [] 
                            {
                                InlineKeyboardButton.WithCallbackData("Преподаватель","Преподаватель")
                            }
                      });

                await Bot.SendTextMessageAsync(message.Chat.Id,"Выберите раздел",replyMarkup: keyborad);

                
                Bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
                {
                    var message = ev.CallbackQuery.Message;
                    if (ev.CallbackQuery.Data == "Абитуриент")
                    {
                        ReplyKeyboardMarkup ReplyKeyboard = new[]
                         {
                                new[] { 
                                    "Какие нужны документы", 
                                    "Сколько нужно набрать для поступления на государственный грант" },
                                new[] { "До какого числа можно сдать документы для поступления", 
                                    "Где можно узнать насчет приемной комисии" },
                            };
                        await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                "Выберите вопрос");

                       
                    }
                    else
                    if (ev.CallbackQuery.Data == "Преподаватель")
                    {
                        ReplyKeyboardMarkup ReplyKeyboard = new[]
                         {
                                new[] {
                                    "Где можно припоркаваться",
                                    "Где можно пообедать" },
                                new[] { "Как уволиться",
                                    "Когда мне дадут отпуск" },
                            };
                        await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                "Выберите вопрос");
                        
                    }
                    else if (ev.CallbackQuery.Data == "Бакалавриат")
                    {
                        ReplyKeyboardMarkup ReplyKeyboard = new[]
                         {
                                new[] {
                                    "Где находится ГМК",
                                    "Где получить справку с места учебы" },
                                new[] { "Где находится ИМС",
                                    "Когда поступить стипедния" },
                        };
                        
                    }
                    
                };

                }
            }
        }


