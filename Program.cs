﻿using ApiAiSDK;
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        static TelegramBotClient Bot;
        static ApiAi apiAi;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("1066585479:AAFk9ZUSZ5aeAniFL90MGP16zAi3fPcqsa4");
            AIConfiguration config = new AIConfiguration("1d10b7a44c644b1ab656235feeafcca7", SupportedLanguage.Russian);
            apiAi = new ApiAi(config);

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;


            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            var message = e.CallbackQuery.Message;
            string data = e.CallbackQuery.Data;

            switch (data)
            {
                case "Абитуриент":
                var keyboard_first = new InlineKeyboardMarkup(new[]
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

                await Bot.SendTextMessageAsync(message.Chat.Id, e.CallbackQuery.Message.Text, replyMarkup: keyboard_first);
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
                    break;


                case "Бакалавриат":
                var keyboard_second = new InlineKeyboardMarkup(new[]
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

                await Bot.SendTextMessageAsync(message.Chat.Id, e.CallbackQuery.Message.Text, replyMarkup: keyboard_second);
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
                    break;


                case "Преподаватель":
                var keyboard_third = new InlineKeyboardMarkup(new[]
                 {
                            new []
                            {
                                InlineKeyboardButton.WithUrl("Академический календарь","https://drive.google.com/uc?export=download&id=10Z7T0DhO08kwQLA76YI1aYqkP8ZVxBSK"),
                            },
                            new []
                            {
                                InlineKeyboardButton.WithUrl("Скачать форму отчета","https://drive.google.com/uc?export=download&id=1nEEsECD2od_zsFZlgLMWKUnB3f3VOK0T"),
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
                    await Bot.SendTextMessageAsync(message.Chat.Id, e.CallbackQuery.Message.Text, replyMarkup: keyboard_third);
                    break;

                case "МК":
                var keyboard_fourth = new InlineKeyboardMarkup(new[]
               {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Главный учебный корпус","first")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Горно-металлургический институт имени О. Байконурова","second")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Медицинский пункт","third")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Нефтянной корпус","four")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Военная кафедра","five")
                            }

                      });

                await Bot.SendTextMessageAsync(message.Chat.Id, e.CallbackQuery.Message.Text, replyMarkup: keyboard_fourth);
                    
                Bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                {
                    var message = e.CallbackQuery.Message;
                    switch (ev.CallbackQuery.Data)
                    {
                        case "first":
                            float Latitude1 = 43.236422f;
                            float Longitude1 = 76.929755f;
                            await Bot.SendLocationAsync(message.Chat.Id, Latitude1, Longitude1);
                            break;
                        case "second":
                            float Latitude2 = 43.236520f;
                            float Longitude2 = 76.931572f;
                            await Bot.SendLocationAsync(message.Chat.Id, Latitude2, Longitude2);
                            break;
                        case "third":
                            float Latitude3 = 43.237319f;
                            float Longitude3 = 76.934405f;
                            await Bot.SendLocationAsync(message.Chat.Id, Latitude3, Longitude3);
                            break;
                        case "four":
                            float Latitude4 = 43.237093f;
                            float Longitude4 = 76.931374f;
                            await Bot.SendLocationAsync(message.Chat.Id, Latitude4, Longitude4);
                            break;
                        case "five":
                            float Latitude5 = 43.231572f;
                            float Longitude5 = 76.934406f;
                            await Bot.SendLocationAsync(message.Chat.Id, Latitude5, Longitude5);
                            break;

                    }
                };
                    break;
            }

            /*if (buttonText == "Картинка")
            {
                await Bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://cdn.lifehacker.ru/wp-content/uploads/2019/06/telegram_1560950950.jpg");
            }
            else if (buttonText == "Документ")
            {
               // await Bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://drive.google.com/uc?export=download&id=0B3Rr6xomyKzhc09hSW4xOGt2SmlHYl95ZWpRYnVOZkhwa0NJ");
            }

            await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"Вы нажали кнопку {buttonText}");*/

        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} отправил сообщение: '{message.Text}'");

            switch (message.Text)
            {
                case "/start":
                    var keyborad = new InlineKeyboardMarkup(new[]
                     {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Абитуриент","Абитуриент"),
                                InlineKeyboardButton.WithCallbackData("Бакалавриат","Бакалавриат"),
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Преподаватель","Преподаватель"),
                                InlineKeyboardButton.WithCallbackData("Местоположение корпусов SU","МК")
                            }
                      });

                    await Bot.SendTextMessageAsync(message.Chat.Id, "Выберите раздел", replyMarkup: keyborad);
                    break;
                default:
                    var responce = apiAi.TextRequest(message.Text);
                    string answer = responce.Result.Fulfillment.Speech;
                    if (answer == "")
                        answer = "Прости, я тебя не понял";
                    await Bot.SendTextMessageAsync(message.From.Id, answer);
                    break;
            }
        }
    }
}
