using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLSoccerCOM.util;

namespace XMLSoccerCOM
{
    public class XmlSoccerApi
    {
        private readonly string apiKey;

        private readonly FootballDataSoapClient soapClient;

        public XmlSoccerApi(string apiKey, string apiUrl)
        {
            this.apiKey = apiKey;

            BasicHttpBinding binding = new BasicHttpBinding();

            EndpointAddress address =
                new EndpointAddress(apiUrl);
            soapClient = new FootballDataSoapClient(binding, address);
        }

        /// <summary>
        /// Gets a list of matches within the date-interval specified. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for all leagues</returns>
        public List<Match> GetFixturesByDateInterval(DateTime dateFrom, DateTime dateTo)
        {
            XmlElement xml = soapClient.GetFixturesByDateInterval(apiKey, createDateTimeString(dateFrom),
                createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a list of matches within the date-interval specified. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for all leagues</returns>
        public async Task<List<Match>> GetFixturesByDateIntervalAsync(DateTime dateFrom, DateTime dateTo)
        {
            GetFixturesByDateIntervalResponse response = await soapClient.GetFixturesByDateIntervalAsync(apiKey,
                createDateTimeString(dateFrom),
                createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetFixturesByDateIntervalResult));

            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a list of matches within the date-interval specified and in the specified league. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="league">Use full name or ID - see xmlsoccer.wikia.com/wiki/Input_data_formats</param>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for the specified league</returns>
        public List<Match> GetFixturesByDateIntervalAndLeague(DateTime dateFrom, DateTime dateTo, string league)
        {
            XmlElement xml = soapClient.GetFixturesByDateIntervalAndLeague(league,
                apiKey, createDateTimeString(dateFrom), createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a list of matches within the date-interval specified and in the specified league. "ID" will always be 0 as all ID's a recorded in to the Match "FixtureMatch_Id" field. You shouldn't use this method if you are trying to get results from already played matches, as this method will only return a very limited amount of data per match.
        /// </summary>
        /// <param name="league">Use full name or ID - see xmlsoccer.wikia.com/wiki/Input_data_formats</param>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <returns>List of "Match" object within the desired date interval for the specified league</returns>
        public async Task<List<Match>> GetFixturesByDateIntervalAndLeagueAsync(DateTime dateFrom, DateTime dateTo,
            string league)
        {
            GetFixturesByDateIntervalAndLeagueResponse response =
                await soapClient.GetFixturesByDateIntervalAndLeagueAsync(league,
                    apiKey, createDateTimeString(dateFrom), createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetFixturesByDateIntervalAndLeagueResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a list of fixtures for a given team in a given date interval
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <param name="teamId">Full name OR numeric ID of team</param>
        /// <returns>List of "Match" object within the desired date interval for the desired team</returns>
        public List<Match> GetFixturesByDateIntervalAndTeam(DateTime dateFrom, DateTime dateTo, string teamId)
        {
            XmlElement xml = soapClient.GetFixturesByDateIntervalAndTeam(apiKey,
                createDateTimeString(dateFrom), createDateTimeString(dateTo), teamId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a list of fixtures for a given team in a given date interval
        /// </summary>
        /// <param name="dateFrom">Date start</param>
        /// <param name="dateTo">Date end</param>
        /// <param name="teamId">Full name OR numeric ID of team</param>
        /// <returns>List of "Match" object within the desired date interval for the desired team</returns>
        public async Task<List<Match>> GetFixturesByDateIntervalAndTeamAsync(DateTime dateFrom, DateTime dateTo,
            string teamId)
        {
            GetFixturesByDateIntervalAndTeamResponse response = await soapClient.GetFixturesByDateIntervalAndTeamAsync(
                apiKey,
                createDateTimeString(dateFrom), createDateTimeString(dateTo), teamId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetFixturesByDateIntervalAndTeamResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Get fixtures for the entire season
        /// </summary>
        /// <param name="league">Specify name or numeric ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>All fixtures for the season</returns>
        public List<Match> GetFixturesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            XmlElement xml = soapClient.GetFixturesByLeagueAndSeason(apiKey, season, league);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Get fixtures for the entire season
        /// </summary>
        /// <param name="league">Specify name or numeric ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>All fixtures for the season</returns>
        public async Task<List<Match>> GetFixturesByLeagueAndSeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            GetFixturesByLeagueAndSeasonResponse response =
                await soapClient.GetFixturesByLeagueAndSeasonAsync(apiKey, season, league);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetFixturesByLeagueAndSeasonResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Gets a specific match after it has finished. Is used to get more information on the match.
        /// </summary>
        /// <param name="fixtureMatchId"></param>
        /// <returns></returns>
        public Match GetHistoricMatchByFixtureMatchId(int fixtureMatchId)
        {
            XmlElement xml = soapClient.GetHistoricMatchesByFixtureMatchID(apiKey, fixtureMatchId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).FirstOrDefault();
        }

        /// <summary>
        /// Gets a specific match after it has finished. Is used to get more information on the match.
        /// </summary>
        /// <param name="fixtureMatchId"></param>
        /// <returns></returns>
        public async Task<Match> GetHistoricMatchByFixtureMatchIdAsync(int fixtureMatchId)
        {
            GetHistoricMatchesByFixtureMatchIDResponse response =
                await soapClient.GetHistoricMatchesByFixtureMatchIDAsync(apiKey, fixtureMatchId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetHistoricMatchesByFixtureMatchIDResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).FirstOrDefault();
        }

        /// <summary>
        /// Retrieve historical matches from a league in a given time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="league"></param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByLeagueAndDateInterval(DateTime dateFrom, DateTime dateTo, string league)
        {
            XmlElement xml = soapClient.GetHistoricMatchesByLeagueAndDateInterval(apiKey, league,
                createDateTimeString(dateFrom),
                createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve historical matches from a league in a given time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="league"></param>
        /// <returns></returns>
        public async Task<List<Match>> GetHistoricMatchesByLeagueAndDateIntervalAsync(DateTime dateFrom,
            DateTime dateTo, string league)
        {
            GetHistoricMatchesByLeagueAndDateIntervalResponse response =
                await soapClient.GetHistoricMatchesByLeagueAndDateIntervalAsync(apiKey, league,
                    createDateTimeString(dateFrom),
                    createDateTimeString(dateTo));
            XDocument xDoc =
                XDocument.Load(new XmlNodeReader(response.Body.GetHistoricMatchesByLeagueAndDateIntervalResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all already played matches in one league a specific season
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            XmlElement xml = soapClient.GetHistoricMatchesByLeagueAndSeason(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all already played matches in one league a specific season
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns></returns>
        public async Task<List<Match>> GetHistoricMatchesByLeagueAndSeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            GetHistoricMatchesByLeagueAndSeasonResponse response =
                await soapClient.GetHistoricMatchesByLeagueAndSeasonAsync(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetHistoricMatchesByLeagueAndSeasonResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all matches where a specific team participated within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByTeamAndDateInterval(DateTime dateFrom, DateTime dateTo, string teamId)
        {
            XmlElement xml = soapClient.GetHistoricMatchesByTeamAndDateInterval(apiKey, teamId,
                createDateTimeString(dateFrom),
                createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all matches where a specific team participated within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team</param>
        /// <returns></returns>
        public async Task<List<Match>> GetHistoricMatchesByTeamAndDateIntervalAsync(DateTime dateFrom, DateTime dateTo,
            string teamId)
        {
            GetHistoricMatchesByTeamAndDateIntervalResponse response =
                await soapClient.GetHistoricMatchesByTeamAndDateIntervalAsync(apiKey, teamId,
                    createDateTimeString(dateFrom),
                    createDateTimeString(dateTo));
            XDocument xDoc =
                XDocument.Load(new XmlNodeReader(response.Body.GetHistoricMatchesByTeamAndDateIntervalResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all matches where two teams played against each other within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team1</param>
        /// <param name="team2Id">Name or numeric ID of team2</param>
        /// <returns></returns>
        public List<Match> GetHistoricMatchesByTeamsAndDateInterval(DateTime dateFrom, DateTime dateTo, string teamId,
            string team2Id)
        {
            XmlElement xml = soapClient.GetHistoricMatchesByTeamsAndDateInterval(apiKey, teamId, team2Id,
                createDateTimeString(dateFrom),
                createDateTimeString(dateTo));
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve all matches where two teams played against each other within a time interval
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="teamId">Name or numeric ID of team1</param>
        /// <param name="team2Id">Name or numeric ID of team2</param>
        /// <returns></returns>
        public async Task<List<Match>> GetHistoricMatchesByTeamsAndDateIntervalAsync(DateTime dateFrom, DateTime dateTo,
            string teamId,
            string team2Id)
        {
            GetHistoricMatchesByTeamsAndDateIntervalResponse response =
                await soapClient.GetHistoricMatchesByTeamsAndDateIntervalAsync(apiKey, teamId, team2Id,
                    createDateTimeString(dateFrom),
                    createDateTimeString(dateTo));
            XDocument xDoc =
                XDocument.Load(new XmlNodeReader(response.Body.GetHistoricMatchesByTeamsAndDateIntervalResult));

            CheckForErrors(xDoc);
            return (from matchElement in xDoc.Descendants("Match")
                select XmlConverter.ReadHistoricalMatch(matchElement)).ToList();
        }

        /// <summary>
        /// Retrieve list of leaguestandings
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>Full standings</returns>
        public List<TeamLeagueStanding> GetLeagueStandingsBySeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            XmlElement xml = soapClient.GetLeagueStandingsBySeason(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);

            XNamespace ns = "http://xmlsoccer.com/LeagueStanding";
            return (from b in xDoc.Descendants(ns + "TeamLeagueStanding")
                select XmlConverter.ReadTeamLeagueStanding(b)
            ).ToList();
        }

        /// <summary>
        /// Retrieve list of leaguestandings
        /// </summary>
        /// <param name="league">Name or numerical ID of league</param>
        /// <param name="seasonStartYear">The year the season started</param>
        /// <returns>Full standings</returns>
        public async Task<List<TeamLeagueStanding>> GetLeagueStandingsBySeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            GetLeagueStandingsBySeasonResponse response =
                await soapClient.GetLeagueStandingsBySeasonAsync(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetLeagueStandingsBySeasonResult));

            CheckForErrors(xDoc);

            XNamespace ns = "http://xmlsoccer.com/LeagueStanding";
            return (from b in xDoc.Descendants(ns + "TeamLeagueStanding")
                select XmlConverter.ReadTeamLeagueStanding(b)
            ).ToList();
        }

        /// <summary>
        /// Get currently played matches from all leagues
        /// </summary>
        /// <returns>List of all matches currently being followed on xmlsoccer.com</returns>
        public List<Match> GetLiveScore()
        {
            XmlElement xml = soapClient.GetLiveScore(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Match") select XmlConverter.ReadLiveMatch(b)
            ).ToList();
        }

        /// <summary>
        /// Get currently played matches from all leagues
        /// </summary>
        /// <returns>List of all matches currently being followed on xmlsoccer.com</returns>
        public async Task<List<Match>> GetLiveScoreAsync()
        {
            GetLiveScoreResponse response = await soapClient.GetLiveScoreAsync(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetLiveScoreResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Match") select XmlConverter.ReadLiveMatch(b)
            ).ToList();
        }

        /// <summary>
        ///  Get currently played matches from specific league
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <returns>List of all matches currently being followed on xmlsoccer.com in a specific league</returns>
        public List<Match> GetLiveScoreByLeague(string league)
        {
            XmlElement xml = soapClient.GetLiveScoreByLeague(apiKey, league);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Match") select XmlConverter.ReadLiveMatch(b)
            ).ToList();
        }

        /// <summary>
        ///  Get currently played matches from specific league
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <returns>List of all matches currently being followed on xmlsoccer.com in a specific league</returns>
        public async Task<List<Match>> GetLiveScoreByLeagueAsync(string league)
        {
            GetLiveScoreByLeagueResponse response = await soapClient.GetLiveScoreByLeagueAsync(apiKey, league);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetLiveScoreByLeagueResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Match") select XmlConverter.ReadLiveMatch(b)
            ).ToList();
        }

        /// <summary>
        /// Gets list of topscorers for the requested league and season
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns>List of topscorers</returns>
        public List<Topscorer> GetTopScorersByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            XmlElement xml = soapClient.GetTopScorersByLeagueAndSeason(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Topscorer") select XmlConverter.ReadTopscorer(b)
            ).ToList();
        }

        /// <summary>
        /// Gets list of topscorers for the requested league and season
        /// </summary>
        /// <param name="league">Name or numeric ID of league</param>
        /// <param name="seasonStartYear">Year that the season started</param>
        /// <returns>List of topscorers</returns>
        public async Task<List<Topscorer>> GetTopScorersByLeagueAndSeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            GetTopScorersByLeagueAndSeasonResponse response =
                await soapClient.GetTopScorersByLeagueAndSeasonAsync(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetTopScorersByLeagueAndSeasonResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Topscorer") select XmlConverter.ReadTopscorer(b)
            ).ToList();
        }

        /// <summary>
        /// Retrieve a specific team
        /// </summary>
        /// <param name="teamName">Either full teamname or numerical ID</param>
        /// <returns>Team information</returns>
        public Team GetTeam(string teamName)
        {
            XmlElement xml = soapClient.GetTeam(apiKey, teamName);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Team") select XmlConverter.ReadTeam(b)
            ).FirstOrDefault();
        }
        
        /// <summary>
        /// Retrieve a specific team
        /// </summary>
        /// <param name="teamName">Either full teamname or numerical ID</param>
        /// <returns>Team information</returns>
        public async Task<Team> GetTeamAsync(string teamName)
        {
            GetTeamResponse response = await soapClient.GetTeamAsync(apiKey, teamName);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetTeamResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Team") select XmlConverter.ReadTeam(b)
            ).FirstOrDefault();
        }        

        /// <summary>
        /// Retrieve all teams
        /// </summary>
        /// <returns>All teams</returns>
        public List<Team> GetAllTeams()
        {
            XmlElement xml = soapClient.GetAllTeams(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Team") select XmlConverter.ReadTeam(b)
            ).ToList();
        }
        
        /// <summary>
        /// Retrieve all teams
        /// </summary>
        /// <returns>All teams</returns>
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            GetAllTeamsResponse response = await soapClient.GetAllTeamsAsync(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllTeamsResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Team") select XmlConverter.ReadTeam(b)
            ).ToList();
        }

        /// <summary>
        /// Retrieve all teams for a particular league and season
        /// </summary>
        /// <returns>All teams</returns>
        public List<Team> GetAllTeamsByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            XmlElement xml = soapClient.GetAllTeamsByLeagueAndSeason(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));

            CheckForErrors(xDoc);

            XNamespace ns = "http://xmlsoccer.com/Team";
            return (from b in xDoc.Descendants(ns + "Team")
                select XmlConverter.ReadTeamWithNs(b)
            ).ToList();
        }
        
        /// <summary>
        /// Retrieve all teams for a particular league and season
        /// </summary>
        /// <returns>All teams</returns>
        public async Task<List<Team>> GetAllTeamsByLeagueAndSeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);

            GetAllTeamsByLeagueAndSeasonResponse response = await soapClient.GetAllTeamsByLeagueAndSeasonAsync(apiKey, league, season);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllTeamsByLeagueAndSeasonResult));

            CheckForErrors(xDoc);

            XNamespace ns = "http://xmlsoccer.com/Team";
            return (from b in xDoc.Descendants(ns + "Team")
                select XmlConverter.ReadTeamWithNs(b)
            ).ToList();
        }

        /// <summary>
        /// Retrieve all leagues
        /// </summary>
        /// <returns>All leagues</returns>
        public List<League> GetAllLeagues()
        {
            XmlElement xml = soapClient.GetAllLeagues(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("League") select XmlConverter.ReadLeague(b)
            ).ToList();
        }
        
        /// <summary>
        /// Retrieve all leagues
        /// </summary>
        /// <returns>All leagues</returns>
        public async Task<List<League>> GetAllLeaguesAsync()
        {
            GetAllLeaguesResponse response = await soapClient.GetAllLeaguesAsync(apiKey);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllLeaguesResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("League") select XmlConverter.ReadLeague(b)
            ).ToList();
        }        

        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetOddsByFixtureMatch(Match match)
        {
            if (match.FixtureMatchId != 0)
            {
                XmlElement xml = soapClient.GetOddsByFixtureMatchId2(apiKey, match.FixtureMatchId.ToString());
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOdds(b)
                ).ToList();
            }

            return null;
        }
        
        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public async Task<List<Odds>> GetOddsByFixtureMatchAsync(Match match)
        {
            if (match.FixtureMatchId != 0)
            {
                GetOddsByFixtureMatchId2Response response = await soapClient.GetOddsByFixtureMatchId2Async(apiKey, match.FixtureMatchId.ToString());
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetOddsByFixtureMatchId2Result));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOdds(b)
                ).ToList();
            }

            return null;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetAllOddsByFixtureMatch(Match match)
        {
            if (match.FixtureMatchId != null)
            {
                XmlElement xml = soapClient.GetAllOddsByFixtureMatchId(apiKey, match.FixtureMatchId.Value);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOdds(b)
                ).ToList();
            }

            return null;
        }
        
        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="match">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public async Task<List<Odds>> GetAllOddsByFixtureMatchAsync(Match match)
        {
            if (match.FixtureMatchId != null)
            {
                GetAllOddsByFixtureMatchIdResponse response = await soapClient.GetAllOddsByFixtureMatchIdAsync(apiKey, match.FixtureMatchId.Value);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllOddsByFixtureMatchIdResult));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOdds(b)
                ).ToList();
            }

            return null;
        }

        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="matchId">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetAllOddsByFixtureMatch(int matchId)
        {
            XmlElement xml = soapClient.GetAllOddsByFixtureMatchId(apiKey, matchId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOddsAll(b)
            ).ToList();
        }
        
        /// <summary>
        /// Gets market information (odds) from various bookmakers
        /// </summary>
        /// <param name="matchId">The match you want to retrieve odds from. Keep in mind odds normally aren't released more than a week prior kickoff</param>
        /// <returns>List of Odds</returns>
        public async Task<List<Odds>> GetAllOddsByFixtureMatchAsync(int matchId)
        {
            GetAllOddsByFixtureMatchIdResponse response = await soapClient.GetAllOddsByFixtureMatchIdAsync(apiKey, matchId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllOddsByFixtureMatchIdResult));
            CheckForErrors(xDoc);
            return (from b in xDoc.Descendants("Odds") select XmlConverter.ReadOddsAll(b)
            ).ToList();
        }        

        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="fixtureMatchId">The fixtureMatch_Id of the match</param>
        /// <returns>List of Odds</returns>
        public List<Odds> GetOddsByFixtureMatch(int fixtureMatchId)
        {
            if (fixtureMatchId != 0)
            {
                XmlElement xml = soapClient.GetOddsByFixtureMatchId2(apiKey, fixtureMatchId.ToString());
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Bookmaker") select XmlConverter.ReadOddFixtureMatchId(b)
                ).ToList();
            }

            return null;
        }
        
        /// <summary>
        /// Gets market information (odds) from various bookmakers, deprecated - use GetAllOddsByFixtureMatch
        /// </summary>
        /// <param name="fixtureMatchId">The fixtureMatch_Id of the match</param>
        /// <returns>List of Odds</returns>
        public async Task<List<Odds>> GetOddsByFixtureMatchAsync(int fixtureMatchId)
        {
            if (fixtureMatchId != 0)
            {
                GetOddsByFixtureMatchId2Response response = await soapClient.GetOddsByFixtureMatchId2Async(apiKey, fixtureMatchId.ToString());
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetOddsByFixtureMatchId2Result));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Bookmaker") select XmlConverter.ReadOddFixtureMatchId(b)
                ).ToList();
            }

            return null;
        }        

        /// <summary>
        /// Gets playerdata
        /// </summary>
        /// <param name="playerId">The id (unique) of the player</param>
        /// <returns>Player details</returns>
        public Player GetPlayerById(int playerId)
        {
            if (playerId != 0)
            {
                XmlElement xml = soapClient.GetPlayerById(apiKey, playerId);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Player") select XmlConverter.ReadPlayer(b)
                ).FirstOrDefault();
            }

            return null;
        }
        
        /// <summary>
        /// Gets playerdata
        /// </summary>
        /// <param name="playerId">The id (unique) of the player</param>
        /// <returns>Player details</returns>
        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            if (playerId != 0)
            {
                GetPlayerByIdResponse response = await soapClient.GetPlayerByIdAsync(apiKey, playerId);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetPlayerByIdResult));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Player") select XmlConverter.ReadPlayer(b)
                ).FirstOrDefault();
            }

            return null;
        }        

        /// <summary>
        /// Gets playerdata for all players from a specific team
        /// </summary>
        /// <param name="teamId">The name or numeric Id of team</param>
        /// <returns>List of players currently signed by the specific team</returns>
        public List<Player> GetPlayerById(string teamId)
        {
            if (!string.IsNullOrEmpty(teamId))
            {
                XmlElement xml = soapClient.GetPlayersByTeam(apiKey, teamId);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Player") select XmlConverter.ReadPlayer(b)
                ).ToList();
            }

            return null;
        }
        
        /// <summary>
        /// Gets playerdata for all players from a specific team
        /// </summary>
        /// <param name="teamId">The name or numeric Id of team</param>
        /// <returns>List of players currently signed by the specific team</returns>
        public async Task<List<Player>> GetPlayerByIdAsync(string teamId)
        {
            if (!string.IsNullOrEmpty(teamId))
            {
                GetPlayersByTeamResponse response = await soapClient.GetPlayersByTeamAsync(apiKey, teamId);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetPlayersByTeamResult));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Player") select XmlConverter.ReadPlayer(b)
                ).ToList();
            }

            return null;
        }        

        /// <summary>
        /// Gets Groups for specific league - can only be used in pro mode as demo league does not contain groups
        /// </summary>
        /// <param name="league">The name or numeric Id of league. League must be a Cup</param>
        /// <param name="seasonStartYear">The year the first match in this season was played.</param>
        /// <returns>List of groups in specific league</returns>
        public List<Group> GetAllGroupsByLeagueAndSeason(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            if (!String.IsNullOrEmpty(league))
            {
                XmlElement xml = soapClient.GetAllGroupsByLeagueAndSeason(apiKey, league, season);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Group") select XmlConverter.ReadGroup(b)
                ).ToList();
            }

            return null;
        }
        
        /// <summary>
        /// Gets Groups for specific league - can only be used in pro mode as demo league does not contain groups
        /// </summary>
        /// <param name="league">The name or numeric Id of league. League must be a Cup</param>
        /// <param name="seasonStartYear">The year the first match in this season was played.</param>
        /// <returns>List of groups in specific league</returns>
        public async Task<List<Group>> GetAllGroupsByLeagueAndSeasonAsync(string league, int seasonStartYear)
        {
            string season = seasonStartYear.ToString().Substring(2) + (seasonStartYear + 1).ToString().Substring(2);
            if (!String.IsNullOrEmpty(league))
            {
                GetAllGroupsByLeagueAndSeasonResponse response  = await soapClient.GetAllGroupsByLeagueAndSeasonAsync(apiKey, league, season);
                XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetAllGroupsByLeagueAndSeasonResult));
                CheckForErrors(xDoc);
                return (from b in xDoc.Descendants("Group") select XmlConverter.ReadGroup(b)
                ).ToList();
            }

            return null;
        }        

        /// <summary>
        /// Retrieve list of leaguestandings for given group - only applicable using the pro-mode (Demo league does not contain groups)
        /// </summary>
        /// <param name="groupId">Numeric Group ID</param>
        /// <returns>Full Group standings</returns>
        public List<TeamLeagueStanding> GetCupStandingsByGroupId(int groupId)
        {
            XmlElement xml = soapClient.GetCupStandingsByGroupId(apiKey, groupId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(xml));
            CheckForErrors(xDoc);
            XNamespace ns = "http://xmlsoccer.com/TeamCupStanding";
            return (from b in xDoc.Descendants(ns + "TeamCupStanding") select XmlConverter.ReadTeamCupStanding(b)
            ).ToList();
        }
        
        /// <summary>
        /// Retrieve list of leaguestandings for given group - only applicable using the pro-mode (Demo league does not contain groups)
        /// </summary>
        /// <param name="groupId">Numeric Group ID</param>
        /// <returns>Full Group standings</returns>
        public async Task<List<TeamLeagueStanding>> GetCupStandingsByGroupIdAsync(int groupId)
        {
            GetCupStandingsByGroupIdResponse response = await soapClient.GetCupStandingsByGroupIdAsync(apiKey, groupId);
            XDocument xDoc = XDocument.Load(new XmlNodeReader(response.Body.GetCupStandingsByGroupIdResult));
            CheckForErrors(xDoc);
            XNamespace ns = "http://xmlsoccer.com/TeamCupStanding";
            return (from b in xDoc.Descendants(ns + "TeamCupStanding") select XmlConverter.ReadTeamCupStanding(b)
            ).ToList();
        }        

        private static void CheckForErrors(XDocument xDoc)
        {
            if (xDoc.Root.Value.Contains(
                "To avoid misuse of the service, you are not allowed to request data again (for this specific method) so soon.")
            )
                throw new TooFrequentRequestException(xDoc.Root.Value);
            if (xDoc.Root.Value.Contains("We were unable to verify your API-key with our database."))
                throw new InvalidAPIKeyException(xDoc.Root.Value);
            if (xDoc.Root.Value.Contains("Error: The ID ("))
                throw new InvalidIDException(xDoc.Root.Value);
        }

        private string createDateTimeString(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }
    }
}