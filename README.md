# XmlSoccerComNet

Prod sample:

            XmlSoccerApi api = new XmlSoccerApi("YourApiKey", "http://xmlsoccer.com/FootballData.asmx");
            List<Match> matches =
                await api.GetHistoricMatchesByLeagueAndDateIntervalAsync(
                    DateTime.Now.Subtract(TimeSpan.FromDays(30)), DateTime.Now, "3");
