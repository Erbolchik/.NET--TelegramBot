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
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1066585479:AAEGSIgm1xwg3o94OEoEBLpMD8oAOnpxo48");

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
                                InlineKeyboardButton.WithCallbackData("Как поступить в SU?","first")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Список документов для поступления","second")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("В какое время можно подать документы? Можно ли сделать это в субботу или воскресенье?","third")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Могу ли я подать документы лично, если мне меньше 18 лет? Или обязательно присутствие родителей?","four")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Контакты приемной комиссии?","five")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("График работы приемной комиссии?","six")
                            }
                      });

                        await Bot.SendTextMessageAsync(message.Chat.Id, ev.CallbackQuery.Message.Text, replyMarkup: keyborad);
                        Bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                        {
                            var message = ev.CallbackQuery.Message;
                            switch (ev.CallbackQuery.Data)
                            {
                                case "first":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Зарегистрироваться в онлайн режиме по адресу kb.satbayev.university");
                                    break;
                                case "second":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "1. Заявление на поступление 2.Аттестат о среднем общем или диплом о начальном профессиональном или среднем профессиональном образовании(оригинал) 3.Фото формата 3х4 – 6шт 4.Медицинская справка по форме 086 - У 5.Прививочная карта по форме 063 6.Снимок флюорографии 7.Документ, подтверждающий преимущественное право 8.Сертификат ЕНТ или комплексного тестирования 9.Свидетельство о присуждении гранта(при его наличии) 10.Копия удостоверении личности 11.Приписное свидетельство ");
                                    break;
                                case "third":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Подать документы можно в рабочие часы Приёмной комиссии. Они будут объявлены ближе к старту приёмной кампании.");
                                    break;
                                case "four":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Вы можете подать документы и самостоятельно, только не забудьте взять с собой паспорт. Но помните: если вы поступаете на место на коммерческой основе, то заключить договор, будучи несовершеннолетним, вы самостоятельно не сможете — необходимо присутствие родителя. Кроме того, если вам меньше 18, вам обязательно нужно будет принести форму согласия на обработку ваших персональных данных, подписанную родителем или опекуном (без неё документы не примут!).");
                                    break;
                                case "five":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Республика Казахстан, г. Алматы, ул. Сатпаева 22а, Главный учебный корпус (ГУК). Вход со стороны ул. Байтурсынова. +7 (727) 292 7301  +7 (727) 292 7779  +7 (727) 320 4112 undgrad@satbayev.university");
                                    break;
                                case "six":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "График работы: пн - пт, с 8:30 до 17:30 сб, с 9:00 до 17:00 ");
                                    break;
                            }
                        };

                    }



                    else
                    if (ev.CallbackQuery.Data == "Бакалавриат")
                    {
                        var keyborad = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Есть ли общежитие? Какие критерии и требования для получения комнаты в общежитии SU?","first"),
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Имеется ли в университете военная кафедра? Есть ли необходимость доплаты за военную кафедру?","second"),
                                },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Что такое кредитная технология обучения?","third"),
                                },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Какие студентческие сообщества есть в университете?","forth"),
                                },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Как вступить в один из таких сообществ?","fifth"),
                                },
                            new []
                            {
                            InlineKeyboardButton.WithCallbackData("При каких обстоятельствах студент лишается гранта","sixth"),
                                }
});

                        await Bot.SendTextMessageAsync(message.Chat.Id, ev.CallbackQuery.Message.Text, replyMarkup: keyborad);
                        Bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                        {
                            var message = ev.CallbackQuery.Message;
                            switch (ev.CallbackQuery.Data)
                            {
                                case "firth":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Да, в SU есть общежитие. Для того, чтобы получить место в общежитии необходимо написать заявление, все заявления в конце августа рассматривает комиссия. В первую очередь места предоставляются иногородним первокурсникам для благополучной адаптации и привыканию к новому месту жительства в первый год обучения. Вторым не маловажным условием для получения места в общежитии является материальное положение студента (при наличии подтверждающих документов).");
                                    break;
                                case "second":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "В университете имеется военная кафедра, зачисление юношей на военную подготовку производится после 1 курса на конкурсной основе. Для обучения на военной кафедре выделяется государственный заказ.");
                                    break;
                                case "third":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Кредитная технология обучения – способ организации учебного процесса, при котором обучающиеся в определенных границах имеют возможность индивидуально планировать последовательность образовательной траектории.");
                                    break;
                                case "forth":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "«Жас Отан», «Лига Волонтеров», Дебатные клубы, Enactus, Society of Automotive Engineers, American Association of Petroleum Geologists, Society of Petroleum Engineers");
                                    break;
                                case "fifth":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ежегодно в сентябре проводится «Ярмарка студенческих сообществ», во время которой каждый желающий может открыть и презентовать свое сообщество или вступить в то сообщество, которое ему понравилось.");
                                    break;
                                case "sixth":
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Обучающиеся, обладатели образовательных грантов, оставленные на повторный курс обучения, лишаются образовательного гранта и продолжают свое дальнейшее обучение на платной основе. Если годовой gpa будет меньше 1,6 то студент теряет государственный образовательный грант. Если студент в итоге за дисциплину получает удовлетворительную оценку, то студент теряет стипендию.");
                                    break;
                            }
                        };

                    }
                    else if (ev.CallbackQuery.Data == "Преподаватель")
                    {
                        var keyborad = new InlineKeyboardMarkup(new[]
                         {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","first"),
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","second"),
                                },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","third"),
                                },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("","forth"),
                                },
new []
                            {
                                InlineKeyboardButton.WithCallbackData("","fifth"),
                                },
                            new []
                            {
                            InlineKeyboardButton.WithCallbackData("","sixth"),
                                }
                      });

                    }

                };
            }


        }
    }
}