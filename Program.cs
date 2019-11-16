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

            if (message.Text != "/start")
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, "Неизвестная команда,повторите попытку");
            }
            else if (message.Text == "/start")
            {
                var keyborad = new InlineKeyboardMarkup(new[]
                     {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Абитуриент","Абитуриент"),
                                InlineKeyboardButton.WithCallbackData("Бакалавриат","Бакалавриат"),
                                InlineKeyboardButton.WithCallbackData("Преподаватель","Преподаватель")
                            }
                      });

            await Bot.SendTextMessageAsync(message.Chat.Id, "Выберите раздел", replyMarkup: keyborad);


                Bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                {
                    var message = ev.CallbackQuery.Message;
                    if (ev.CallbackQuery.Data == "Абитуриент")
                    {
                        var keyborad = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Как поступить в SU?","first"),
                                InlineKeyboardButton.WithCallbackData("Список документов для поступления","second"),
                                InlineKeyboardButton.WithCallbackData("В какое время можно подать документы? Можно ли сделать это в субботу или воскресенье?","third"),
                                InlineKeyboardButton.WithCallbackData("Могу ли я подать документы лично, если мне меньше 18 лет? Или обязательно присутствие родителей?","four"),
                                InlineKeyboardButton.WithCallbackData("Контакты приемной комиссии?","five"),
                                InlineKeyboardButton.WithCallbackData("График работы приемной комиссии?","six")
                            }
                      });

                        await Bot.SendTextMessageAsync(message.Chat.Id, ev.CallbackQuery.Message.Text,replyMarkup:keyborad);
                        Bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                        {
                            var message = ev.CallbackQuery.Message;
                            switch (ev.CallbackQuery.Data)
                            {
                                case "first":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Зарегистрироваться в онлайн режиме по адресу kb.satbayev.university");
                                    break;
                                case "second":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "");
                                    break;
                                case "third":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "");
                                    break;
                                case "four":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "");
                                    break;
                                case "five":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "");
                                    break;
                                case "six":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "");
                                    break;
                            }
                            if (ev.CallbackQuery.Data == "gmk")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "в алмате");
                            }
                            else
                            if (ev.CallbackQuery.Data == "ims")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "в крг");
                            }
                        };
                    }



                    else
                    if (ev.CallbackQuery.Data == "Преподаватель")
                    {
                        var keyborad = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","gmk"),
                                InlineKeyboardButton.WithCallbackData("","ims"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),

                            }
                      });

                    }
                    else if (ev.CallbackQuery.Data == "Бакалавриат")
                    {
                        var keyborad = new InlineKeyboardMarkup(new[]
                         {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","gmk"),
                                InlineKeyboardButton.WithCallbackData("","ims"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),
                                InlineKeyboardButton.WithCallbackData("","мимс"),

                            }
                      });

                    }

                };
            }


        }
    }
}


