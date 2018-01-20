using System;
using System.Xml.Linq;

namespace XMLSoccerCOM.util
{
    // Todo: This thing can probably be replaced with Domain classes with annotations and 
    // something like Newtonsoft json, only for xml. Reflection based.
    public static class XmlConverter
    {
        public static Match ReadMatch(XElement matchElement)
        {
            return new Match
            {
                FixtureMatchId =
                    matchElement.Element("Id") != null ? int.Parse(matchElement.Element("Id").Value) : 0,
                Date = DateTime.Parse(matchElement.Element("Date").Value),
                Round = matchElement.Element("Round") != null ? int.Parse(matchElement.Element("Round").Value) : 0,
                Spectators = matchElement.Element("Spectators") != null
                    ? matchElement.Element("Spectators").Value
                    : null,
                League = matchElement.Element("League").Value,
                HomeTeam = matchElement.Element("HomeTeam").Value,
                HomeTeam_Id = int.Parse(matchElement.Element("HomeTeam_Id").Value),
                HomeGoals = matchElement.Element("HomeGoals") != null
                    ? int.Parse(matchElement.Element("HomeGoals").Value)
                    : 0,
                HomeCorners = matchElement.Element("HomeCorners") != null
                    ? int.Parse(matchElement.Element("HomeCorners").Value)
                    : 0,
                HalfTimeHomeGoals =
                    matchElement.Element("HalfTimeHomeGoals") != null
                        ? int.Parse(matchElement.Element("HalfTimeHomeGoals").Value)
                        : 0,
                HomeShots = matchElement.Element("HomeShots") != null
                    ? int.Parse(matchElement.Element("HomeShots").Value)
                    : 0,
                HomeShotsOnTarget =
                    matchElement.Element("HomeShotsOnTarget") != null
                        ? int.Parse(matchElement.Element("HomeShotsOnTarget").Value)
                        : 0,
                HomeFouls = matchElement.Element("HomeFouls") != null
                    ? int.Parse(matchElement.Element("HomeFouls").Value)
                    : 0,
                AwayTeam = matchElement.Element("AwayTeam").Value,
                AwayTeam_Id = int.Parse(matchElement.Element("AwayTeam_Id").Value),
                AwayGoals = matchElement.Element("AwayGoals") != null
                    ? int.Parse(matchElement.Element("AwayGoals").Value)
                    : 0,
                AwayCorners = matchElement.Element("AwayCorners") != null
                    ? int.Parse(matchElement.Element("AwayCorners").Value)
                    : 0,
                HalfTimeAwayGoals =
                    matchElement.Element("HalfTimeAwayGoals") != null
                        ? int.Parse(matchElement.Element("HalfTimeAwayGoals").Value)
                        : 0,
                AwayShots = matchElement.Element("AwayShots") != null
                    ? int.Parse(matchElement.Element("AwayShots").Value)
                    : 0,
                AwayShotsOnTarget =
                    matchElement.Element("AwayShotsOnTarget") != null
                        ? int.Parse(matchElement.Element("AwayShotsOnTarget").Value)
                        : 0,
                AwayFouls = matchElement.Element("AwayFouls") != null
                    ? int.Parse(matchElement.Element("AwayFouls").Value)
                    : 0,
                Time = matchElement.Element("Time") != null ? matchElement.Element("Time").Value : null,
                Location = matchElement.Element("Location") != null ? matchElement.Element("Location").Value : null,
                HomeTeamYellowCardDetails =
                    matchElement.Element("HomeTeamYellowCardDetails") != null
                        ? matchElement.Element("HomeTeamYellowCardDetails").Value.Split(';')
                        : null,
                AwayTeamYellowCardDetails =
                    matchElement.Element("AwayTeamYellowCardDetails") != null
                        ? matchElement.Element("AwayTeamYellowCardDetails").Value.Split(';')
                        : null,
                HomeTeamRedCardDetails =
                    matchElement.Element("HomeTeamRedCardDetails") != null
                        ? matchElement.Element("HomeTeamRedCardDetails").Value.Split(';')
                        : null,
                AwayTeamRedCardDetails =
                    matchElement.Element("AwayTeamRedCardDetails") != null
                        ? matchElement.Element("AwayTeamRedCardDetails").Value.Split(';')
                        : null,
                HomeGoalDetails =
                    matchElement.Element("HomeGoalDetails") != null
                        ? matchElement.Element("HomeGoalDetails").Value.Split(';')
                        : null,
                AwayGoalDetails =
                    matchElement.Element("AwayGoalDetails") != null
                        ? matchElement.Element("AwayGoalDetails").Value.Split(';')
                        : null,
                HomeLineupDefense =
                    matchElement.Element("HomeLineupDefense") != null
                        ? matchElement.Element("HomeLineupDefense").Value.Split(';')
                        : null,
                HomeLineupGoalkeeper =
                    matchElement.Element("HomeLineupGoalkeeper") != null
                        ? matchElement.Element("HomeLineupGoalkeeper").Value
                        : null,
                HomeLineupMidfield =
                    matchElement.Element("HomeLineupMidfield") != null
                        ? matchElement.Element("HomeLineupMidfield").Value.Split(';')
                        : null,
                HomeLineupForward =
                    matchElement.Element("HomeLineupForward") != null
                        ? matchElement.Element("HomeLineupForward").Value.Split(';')
                        : null,
                AwayLineupGoalkeeper =
                    matchElement.Element("AwayLineupGoalkeeper") != null
                        ? matchElement.Element("AwayLineupGoalkeeper").Value
                        : null,
                AwayLineupDefense =
                    matchElement.Element("AwayLineupDefense") != null
                        ? matchElement.Element("AwayLineupDefense").Value.Split(';')
                        : null,
                AwayLineupMidfield =
                    matchElement.Element("AwayLineupMidfield") != null
                        ? matchElement.Element("AwayLineupMidfield").Value.Split(';')
                        : null,
                AwayLineupForward =
                    matchElement.Element("AwayLineupForward") != null
                        ? matchElement.Element("AwayLineupForward").Value.Split(';')
                        : null,
                HomeSubDetails =
                    matchElement.Element("HomeSubDetails") != null
                        ? matchElement.Element("HomeSubDetails").Value.Split(';')
                        : null,
                AwaySubDetails =
                    matchElement.Element("AwaySubDetails") != null
                        ? matchElement.Element("AwaySubDetails").Value.Split(';')
                        : null,
                HomeTeamFormation =
                    matchElement.Element("HomeTeamFormation") != null
                        ? matchElement.Element("HomeTeamFormation").Value
                        : null,
                AwayTeamFormation =
                    matchElement.Element("AwayTeamFormation") != null
                        ? matchElement.Element("AwayTeamFormation").Value
                        : null,
                Group = matchElement.Element("Group") != null ? matchElement.Element("Group").Value : null,
                Group_Id = matchElement.Element("Group_Id") != null ? matchElement.Element("Group_Id").Value : null,
                HasBeenRescheduled = matchElement.Element("HasBeenRescheduled") != null &&
                                     bool.Parse(matchElement.Element("HasBeenRescheduled").Value)
            };
        }

        public static Match ReadHistoricalMatch(XElement historicMatchElement)
        {
            return new Match
            {
                Id = int.Parse(historicMatchElement.Element("Id").Value),
                FixtureMatchId =
                    historicMatchElement.Element("FixtureMatch_Id") != null
                        ? int.Parse(historicMatchElement.Element("FixtureMatch_Id").Value)
                        : 0,
                Date = DateTime.Parse(historicMatchElement.Element("Date").Value),
                Round = historicMatchElement.Element("Round") != null
                    ? int.Parse(historicMatchElement.Element("Round").Value)
                    : 0,
                Spectators = historicMatchElement.Element("Spectators") != null
                    ? historicMatchElement.Element("Spectators").Value
                    : null,
                League = historicMatchElement.Element("League").Value,
                HomeTeam = historicMatchElement.Element("HomeTeam").Value,
                HomeTeam_Id = int.Parse(historicMatchElement.Element("HomeTeam_Id").Value),
                HomeGoals = int.Parse(historicMatchElement.Element("HomeGoals").Value),
                HomeCorners = historicMatchElement.Element("HomeCorners") != null
                    ? int.Parse(historicMatchElement.Element("HomeCorners").Value)
                    : 0,
                HalfTimeHomeGoals =
                    historicMatchElement.Element("HalfTimeHomeGoals") != null
                        ? int.Parse(historicMatchElement.Element("HalfTimeHomeGoals").Value)
                        : 0,
                HomeShots = historicMatchElement.Element("HomeShots") != null
                    ? int.Parse(historicMatchElement.Element("HomeShots").Value)
                    : 0,
                HomeShotsOnTarget =
                    historicMatchElement.Element("HomeShotsOnTarget") != null
                        ? int.Parse(historicMatchElement.Element("HomeShotsOnTarget").Value)
                        : 0,
                HomeFouls = historicMatchElement.Element("HomeFouls") != null
                    ? int.Parse(historicMatchElement.Element("HomeFouls").Value)
                    : 0,
                AwayTeam = historicMatchElement.Element("AwayTeam").Value,
                AwayTeam_Id = int.Parse(historicMatchElement.Element("AwayTeam_Id").Value),
                AwayGoals = int.Parse(historicMatchElement.Element("AwayGoals").Value),
                AwayCorners = historicMatchElement.Element("AwayCorners") != null
                    ? int.Parse(historicMatchElement.Element("AwayCorners").Value)
                    : 0,
                HalfTimeAwayGoals =
                    historicMatchElement.Element("HalfTimeAwayGoals") != null
                        ? int.Parse(historicMatchElement.Element("HalfTimeAwayGoals").Value)
                        : 0,
                AwayShots = historicMatchElement.Element("AwayShots") != null
                    ? int.Parse(historicMatchElement.Element("AwayShots").Value)
                    : 0,
                AwayShotsOnTarget =
                    historicMatchElement.Element("AwayShotsOnTarget") != null
                        ? int.Parse(historicMatchElement.Element("AwayShotsOnTarget").Value)
                        : 0,
                AwayFouls = historicMatchElement.Element("AwayFouls") != null
                    ? int.Parse(historicMatchElement.Element("AwayFouls").Value)
                    : 0,
                Time = historicMatchElement.Element("Time") != null ? historicMatchElement.Element("Time").Value : null,
                Location = historicMatchElement.Element("Location") != null
                    ? historicMatchElement.Element("Location").Value
                    : null,
                HomeTeamYellowCardDetails =
                    historicMatchElement.Element("HomeTeamYellowCardDetails") != null
                        ? historicMatchElement.Element("HomeTeamYellowCardDetails").Value.Split(';')
                        : null,
                AwayTeamYellowCardDetails =
                    historicMatchElement.Element("AwayTeamYellowCardDetails") != null
                        ? historicMatchElement.Element("AwayTeamYellowCardDetails").Value.Split(';')
                        : null,
                HomeTeamRedCardDetails =
                    historicMatchElement.Element("HomeTeamRedCardDetails") != null
                        ? historicMatchElement.Element("HomeTeamRedCardDetails").Value.Split(';')
                        : null,
                AwayTeamRedCardDetails =
                    historicMatchElement.Element("AwayTeamRedCardDetails") != null
                        ? historicMatchElement.Element("AwayTeamRedCardDetails").Value.Split(';')
                        : null,
                HomeGoalDetails =
                    historicMatchElement.Element("HomeGoalDetails") != null
                        ? historicMatchElement.Element("HomeGoalDetails").Value.Split(';')
                        : null,
                AwayGoalDetails =
                    historicMatchElement.Element("AwayGoalDetails") != null
                        ? historicMatchElement.Element("AwayGoalDetails").Value.Split(';')
                        : null,
                HomeLineupDefense =
                    historicMatchElement.Element("HomeLineupDefense") != null
                        ? historicMatchElement.Element("HomeLineupDefense").Value.Split(';')
                        : null,
                HomeLineupGoalkeeper =
                    historicMatchElement.Element("HomeLineupGoalkeeper") != null
                        ? historicMatchElement.Element("HomeLineupGoalkeeper").Value
                        : null,
                HomeLineupMidfield =
                    historicMatchElement.Element("HomeLineupMidfield") != null
                        ? historicMatchElement.Element("HomeLineupMidfield").Value.Split(';')
                        : null,
                HomeLineupForward =
                    historicMatchElement.Element("HomeLineupForward") != null
                        ? historicMatchElement.Element("HomeLineupForward").Value.Split(';')
                        : null,
                AwayLineupGoalkeeper =
                    historicMatchElement.Element("AwayLineupGoalkeeper") != null
                        ? historicMatchElement.Element("AwayLineupGoalkeeper").Value
                        : null,
                AwayLineupMidfield =
                    historicMatchElement.Element("AwayLineupMidfield") != null
                        ? historicMatchElement.Element("AwayLineupMidfield").Value.Split(';')
                        : null,
                AwayLineupForward =
                    historicMatchElement.Element("AwayLineupForward") != null
                        ? historicMatchElement.Element("AwayLineupForward").Value.Split(';')
                        : null,
                HomeSubDetails =
                    historicMatchElement.Element("HomeSubDetails") != null
                        ? historicMatchElement.Element("HomeSubDetails").Value.Split(';')
                        : null,
                AwaySubDetails =
                    historicMatchElement.Element("AwaySubDetails") != null
                        ? historicMatchElement.Element("AwaySubDetails").Value.Split(';')
                        : null,
                HomeTeamFormation =
                    historicMatchElement.Element("HomeTeamFormation") != null
                        ? historicMatchElement.Element("HomeTeamFormation").Value
                        : null,
                AwayTeamFormation =
                    historicMatchElement.Element("AwayTeamFormation") != null
                        ? historicMatchElement.Element("AwayTeamFormation").Value
                        : null,
                HomeLineupSubstitutes =
                    historicMatchElement.Element("HomeLineupSubstitutes") != null
                        ? historicMatchElement.Element("HomeLineupSubstitutes").Value.Split(';')
                        : null,
                AwayLineupSubstitutes =
                    historicMatchElement.Element("AwayLineupSubstitutes") != null
                        ? historicMatchElement.Element("AwayLineupSubstitutes").Value.Split(';')
                        : null,
                AwayLineupCoach = historicMatchElement.Element("AwayLineupCoach") != null
                    ? historicMatchElement.Element("AwayLineupCoach").Value
                    : null,
                HomeLineupCoach = historicMatchElement.Element("HomeLineupCoach") != null
                    ? historicMatchElement.Element("HomeLineupCoach").Value
                    : null,
                AwayLineupDefense =
                    historicMatchElement.Element("AwayLineupDefense") != null
                        ? historicMatchElement.Element("AwayLineupDefense").Value.Split(';')
                        : null,
                AwayYellowCards =
                    historicMatchElement.Element("AwayYellowCards") != null
                        ? int.Parse(historicMatchElement.Element("AwayYellowCards").Value)
                        : 0,
                HomeYellowCards =
                    historicMatchElement.Element("HomeYellowCards") != null
                        ? int.Parse(historicMatchElement.Element("HomeYellowCards").Value)
                        : 0,
                HomeRedCards = historicMatchElement.Element("HomeRedCards") != null
                    ? int.Parse(historicMatchElement.Element("HomeRedCards").Value)
                    : 0,
                AwayRedCards = historicMatchElement.Element("AwayRedCards") != null
                    ? int.Parse(historicMatchElement.Element("AwayRedCards").Value)
                    : 0,
                Group = historicMatchElement.Element("Group") != null
                    ? historicMatchElement.Element("Group").Value
                    : null,
                Group_Id = historicMatchElement.Element("Group_Id") != null
                    ? historicMatchElement.Element("Group_Id").Value
                    : null,
                HasBeenRescheduled = historicMatchElement.Element("HasBeenRescheduled") != null &&
                                     bool.Parse(historicMatchElement.Element("HasBeenRescheduled").Value)
            };
        }

        public static TeamLeagueStanding ReadTeamLeagueStanding(XElement xElement)
        {
            XNamespace ns = "http://xmlsoccer.com/LeagueStanding";
            return new TeamLeagueStanding
            {
                Team = xElement.Element(ns + "Team").Value,
                Team_Id = int.Parse(xElement.Element(ns + "Team_Id").Value),
                Played = xElement.Element(ns + "Played") != null
                    ? int.Parse(xElement.Element(ns + "Played").Value)
                    : 0,
                PlayedAtHome =
                    xElement.Element(ns + "PlayedAtHome") != null
                        ? int.Parse(xElement.Element(ns + "PlayedAtHome").Value)
                        : 0,
                PlayedAway =
                    xElement.Element(ns + "PlayedAway") != null
                        ? int.Parse(xElement.Element(ns + "PlayedAway").Value)
                        : 0,
                Won = xElement.Element(ns + "Won") != null ? int.Parse(xElement.Element(ns + "Won").Value) : 0,
                Draw = xElement.Element(ns + "Draw") != null ? int.Parse(xElement.Element(ns + "Draw").Value) : 0,
                Lost = xElement.Element(ns + "Lost") != null ? int.Parse(xElement.Element(ns + "Lost").Value) : 0,
                NumberOfShots =
                    xElement.Element(ns + "NumberOfShots") != null
                        ? int.Parse(xElement.Element(ns + "NumberOfShots").Value)
                        : 0,
                YellowCards =
                    xElement.Element(ns + "YellowCards") != null
                        ? int.Parse(xElement.Element(ns + "YellowCards").Value)
                        : 0,
                RedCards = xElement.Element(ns + "RedCards") != null
                    ? int.Parse(xElement.Element(ns + "RedCards").Value)
                    : 0,
                Goals_For =
                    xElement.Element(ns + "Goals_For") != null
                        ? int.Parse(xElement.Element(ns + "Goals_For").Value)
                        : 0,
                Goals_Against =
                    xElement.Element(ns + "Goals_Against") != null
                        ? int.Parse(xElement.Element(ns + "Goals_Against").Value)
                        : 0,
                Goal_Difference =
                    xElement.Element(ns + "Goal_Difference") != null
                        ? int.Parse(xElement.Element(ns + "Goal_Difference").Value)
                        : 0,
                Points = xElement.Element(ns + "Points") != null
                    ? int.Parse(xElement.Element(ns + "Points").Value)
                    : 0
            };
        }

        public static Match ReadLiveMatch(XElement xElement)
        {
            return new Match
            {
                FixtureMatchId = int.Parse(xElement.Element("Id").Value),
                Date = DateTime.Parse(xElement.Element("Date").Value),
                Round = xElement.Element("Round") != null ? int.Parse(xElement.Element("Round").Value) : 0,
                Spectators = xElement.Element("Spectators") != null ? xElement.Element("Spectators").Value : null,
                League = xElement.Element("League").Value,
                HomeTeam = xElement.Element("HomeTeam").Value,
                HomeTeam_Id = int.Parse(xElement.Element("HomeTeam_Id").Value),
                HomeGoals = xElement.Element("HomeGoals") != null ? int.Parse(xElement.Element("HomeGoals").Value) : 0,
                HomeCorners = xElement.Element("HomeCorners") != null
                    ? int.Parse(xElement.Element("HomeCorners").Value)
                    : 0,
                HalfTimeHomeGoals =
                    xElement.Element("HalfTimeHomeGoals") != null
                        ? int.Parse(xElement.Element("HalfTimeHomeGoals").Value)
                        : 0,
                HomeShots = xElement.Element("HomeShots") != null ? int.Parse(xElement.Element("HomeShots").Value) : 0,
                HomeShotsOnTarget =
                    xElement.Element("HomeShotsOnTarget") != null
                        ? int.Parse(xElement.Element("HomeShotsOnTarget").Value)
                        : 0,
                HomeFouls = xElement.Element("HomeFouls") != null ? int.Parse(xElement.Element("HomeFouls").Value) : 0,
                AwayTeam = xElement.Element("AwayTeam").Value,
                AwayTeam_Id = int.Parse(xElement.Element("AwayTeam_Id").Value),
                AwayGoals = xElement.Element("AwayGoals") != null ? int.Parse(xElement.Element("AwayGoals").Value) : 0,
                AwayCorners = xElement.Element("AwayCorners") != null
                    ? int.Parse(xElement.Element("AwayCorners").Value)
                    : 0,
                HalfTimeAwayGoals =
                    xElement.Element("HalfTimeAwayGoals") != null
                        ? int.Parse(xElement.Element("HalfTimeAwayGoals").Value)
                        : 0,
                AwayShots = xElement.Element("AwayShots") != null ? int.Parse(xElement.Element("AwayShots").Value) : 0,
                AwayShotsOnTarget =
                    xElement.Element("AwayShotsOnTarget") != null
                        ? int.Parse(xElement.Element("AwayShotsOnTarget").Value)
                        : 0,
                AwayFouls = xElement.Element("AwayFouls") != null ? int.Parse(xElement.Element("AwayFouls").Value) : 0,
                Time = xElement.Element("Time") != null ? xElement.Element("Time").Value : null,
                Location = xElement.Element("Location") != null ? xElement.Element("Location").Value : null,
                HomeTeamYellowCardDetails =
                    xElement.Element("HomeTeamYellowCardDetails") != null
                        ? xElement.Element("HomeTeamYellowCardDetails").Value.Split(';')
                        : null,
                AwayTeamYellowCardDetails =
                    xElement.Element("AwayTeamYellowCardDetails") != null
                        ? xElement.Element("AwayTeamYellowCardDetails").Value.Split(';')
                        : null,
                HomeTeamRedCardDetails =
                    xElement.Element("HomeTeamRedCardDetails") != null
                        ? xElement.Element("HomeTeamRedCardDetails").Value.Split(';')
                        : null,
                AwayTeamRedCardDetails =
                    xElement.Element("AwayTeamRedCardDetails") != null
                        ? xElement.Element("AwayTeamRedCardDetails").Value.Split(';')
                        : null,
                HomeGoalDetails =
                    xElement.Element("HomeGoalDetails") != null
                        ? xElement.Element("HomeGoalDetails").Value.Split(';')
                        : null,
                AwayGoalDetails =
                    xElement.Element("AwayGoalDetails") != null
                        ? xElement.Element("AwayGoalDetails").Value.Split(';')
                        : null,
                HomeLineupDefense =
                    xElement.Element("HomeLineupDefense") != null
                        ? xElement.Element("HomeLineupDefense").Value.Split(';')
                        : null,
                HomeLineupGoalkeeper =
                    xElement.Element("HomeLineupGoalkeeper") != null
                        ? xElement.Element("HomeLineupGoalkeeper").Value
                        : null,
                HomeLineupMidfield =
                    xElement.Element("HomeLineupMidfield") != null
                        ? xElement.Element("HomeLineupMidfield").Value.Split(';')
                        : null,
                HomeLineupForward =
                    xElement.Element("HomeLineupForward") != null
                        ? xElement.Element("HomeLineupForward").Value.Split(';')
                        : null,
                AwayLineupGoalkeeper =
                    xElement.Element("AwayLineupGoalkeeper") != null
                        ? xElement.Element("AwayLineupGoalkeeper").Value
                        : null,
                AwayLineupDefense =
                    xElement.Element("AwayLineupDefense") != null
                        ? xElement.Element("AwayLineupDefense").Value.Split(';')
                        : null,
                AwayLineupMidfield =
                    xElement.Element("AwayLineupMidfield") != null
                        ? xElement.Element("AwayLineupMidfield").Value.Split(';')
                        : null,
                AwayLineupForward =
                    xElement.Element("AwayLineupForward") != null
                        ? xElement.Element("AwayLineupForward").Value.Split(';')
                        : null,
                HomeSubDetails =
                    xElement.Element("HomeSubDetails") != null
                        ? xElement.Element("HomeSubDetails").Value.Split(';')
                        : null,
                AwaySubDetails =
                    xElement.Element("AwaySubDetails") != null
                        ? xElement.Element("AwaySubDetails").Value.Split(';')
                        : null,
                HomeTeamFormation =
                    xElement.Element("HomeTeamFormation") != null ? xElement.Element("HomeTeamFormation").Value : null,
                AwayTeamFormation =
                    xElement.Element("AwayTeamFormation") != null ? xElement.Element("AwayTeamFormation").Value : null,
                HomeLineupSubstitutes =
                    xElement.Element("HomeLineupSubstitutes") != null
                        ? xElement.Element("HomeLineupSubstitutes").Value.Split(';')
                        : null,
                AwayLineupSubstitutes =
                    xElement.Element("AwayLineupSubstitutes") != null
                        ? xElement.Element("AwayLineupSubstitutes").Value.Split(';')
                        : null,
                AwayLineupCoach = xElement.Element("AwayLineupCoach") != null
                    ? xElement.Element("AwayLineupCoach").Value
                    : null,
                HomeLineupCoach = xElement.Element("HomeLineupCoach") != null
                    ? xElement.Element("HomeLineupCoach").Value
                    : null,
                Group = xElement.Element("Group") != null ? xElement.Element("Group").Value : null,
                Group_Id = xElement.Element("Group_Id") != null ? xElement.Element("Group_Id").Value : null,
                HasBeenRescheduled = xElement.Element("HasBeenRescheduled") != null &&
                                     bool.Parse(xElement.Element("HasBeenRescheduled").Value)
            };
        }

        public static Topscorer ReadTopscorer(XElement xElement)
        {
            return new Topscorer
            {
                TeamName = xElement.Element("TeamName").Value,
                Nationality = xElement.Element("Nationality").Value,
                Name = xElement.Element("Name").Value,
                Rank = int.Parse(xElement.Element("Rank").Value),
                Team_Id = xElement.Element("Team_Id") != null ? int.Parse(xElement.Element("Team_Id").Value) : 0,
                Goals = xElement.Element("Goals") != null ? int.Parse(xElement.Element("Goals").Value) : 0,
                FirstScorer = xElement.Element("FirstScorer") != null
                    ? int.Parse(xElement.Element("FirstScorer").Value)
                    : 0,
                Penalties = xElement.Element("Penalties") != null ? int.Parse(xElement.Element("Penalties").Value) : 0,
                MissedPenalties = xElement.Element("MissedPenalties") != null
                    ? int.Parse(xElement.Element("MissedPenalties").Value)
                    : 0
            };
        }

        public static Team ReadTeam(XElement xElement)
        {
            return new Team
            {
                Team_Id = int.Parse(xElement.Element("Id").Value),
                Name = xElement.Element("Name").Value,
                WIKILink = xElement.Element("WikiPageUrl") != null ? xElement.Element("WikiPageUrl").Value : null,
                Country = xElement.Element("Country") != null ? xElement.Element("Country").Value : null,
                Stadium = xElement.Element("Stadium") != null ? xElement.Element("Stadium").Value : null,
                HomePageURL = xElement.Element("Website") != null ? xElement.Element("Website").Value : null
            };
        }

        public static Team ReadTeamWithNs(XElement xElement)
        {
            XNamespace ns = "http://xmlsoccer.com/Team";

            return new Team
            {
                Team_Id = int.Parse(xElement.Element(ns + "Team_Id").Value),
                Name = xElement.Element(ns + "Name").Value,
                WIKILink = xElement.Element(ns + "WIKILink") != null ? xElement.Element(ns + "WIKILink").Value : null,
                Country = xElement.Element(ns + "Country") != null ? xElement.Element(ns + "Country").Value : null,
                Stadium = xElement.Element(ns + "Stadium") != null ? xElement.Element(ns + "Stadium").Value : null,
                HomePageURL = xElement.Element(ns + "HomePageURL") != null
                    ? xElement.Element(ns + "HomePageURL").Value
                    : null
            };
        }

        public static League ReadLeague(XElement xElement)
        {
            return new League
            {
                Id = int.Parse(xElement.Element("Id").Value),
                Name = xElement.Element("Name").Value,
                Country = xElement.Element("Country") != null ? xElement.Element("Country").Value : null,
                Historical_Data = xElement.Element("Historical_Data") != null
                    ? xElement.Element("Historical_Data").Value
                    : null,
                Fixtures = xElement.Element("Fixtures") != null && xElement.Element("Fixtures").Value.Contains("Yes"),
                Livescore =
                    xElement.Element("Livescore") != null && xElement.Element("Livescore").Value.Contains("Yes"),
                LatestMatchResult =
                    xElement.Element("LatestMatchResult") != null
                        ? DateTime.Parse(xElement.Element("LatestMatchResult").Value)
                        : DateTime.Now,
                NumberOfMatches = xElement.Element("NumberOfMatches") != null
                    ? int.Parse(xElement.Element("NumberOfMatches").Value)
                    : 0
            };
        }

        public static Odds ReadOdds(XElement b)
        {
            return new Odds
            {
                Name = b.Element("Name").Value,
                Type = "1X2",
                URL = b.Element("URL") != null ? b.Element("URL").Value : null,
                Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value) : 0,
                Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value) : 0,
                Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value) : 0
            };
        }

        public static Odds ReadOddsAll(XElement b)
        {
            return new Odds
            {
                Name = b.Element("Bookmaker").Value,
                URL = null,
                Type = b.Element("Type") != null ? b.Element("Type").Value : null,
                Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value) : 0,
                Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value) : 0,
                Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value) : 0
            };
        }

        public static Odds ReadOddFixtureMatchId(XElement b)
        {
            return new Odds
            {
                Name = b.Element("Name").Value,
                URL = b.Element("URL") != null ? b.Element("URL").Value : null,
                Home = b.Element("Home") != null ? double.Parse(b.Element("Home").Value.Replace(".", ",")) : 0,
                Draw = b.Element("Draw") != null ? double.Parse(b.Element("Draw").Value.Replace(".", ",")) : 0,
                Away = b.Element("Away") != null ? double.Parse(b.Element("Away").Value.Replace(".", ",")) : 0
            };
        }

        public static Player ReadPlayer(XElement b)
        {
            return new Player
            {
                Name = b.Element("Name").Value,
                DateOfBirth =
                    b.Element("DateOfBirth") != null
                        ? DateTime.Parse(b.Element("DateOfBirth").Value)
                        : new DateTime(),
                DateOfSigning =
                    b.Element("DateOfSigning") != null
                        ? DateTime.Parse(b.Element("DateOfSigning").Value)
                        : new DateTime(),
                Height =
                    b.Element("Height") != null ? double.Parse(b.Element("Height").Value.Replace(".", ",")) : 0,
                Id = b.Element("Id") != null ? int.Parse(b.Element("Id").Value) : 0,
                Nationality = b.Element("Nationality") != null ? b.Element("Nationality").Value : null,
                PlayerNumber =
                    b.Element("PlayerNumber") != null ? int.Parse(b.Element("PlayerNumber").Value) : 0,
                Position = b.Element("Position") != null ? b.Element("Position").Value : null,
                Signing = b.Element("Signing") != null ? b.Element("Signing").Value : null,
                Team_Id = b.Element("Team_Id") != null ? int.Parse(b.Element("Team_Id").Value) : 0,
                Weight = b.Element("Weight") != null
                    ? double.Parse(b.Element("Weight").Value.Replace(".", ","))
                    : 0
            };
        }

        public static Group ReadGroup(XElement b)
        {
            return new Group
            {
                Name = b.Element("Name").Value,
                Id = b.Element("Id") != null ? int.Parse(b.Element("Id").Value) : 0,
                Season = b.Element("Season") != null ? b.Element("Season").Value : null,
                League_Id = b.Element("League_Id") != null ? int.Parse(b.Element("League_Id").Value) : 0
            };
        }

        public static TeamLeagueStanding ReadTeamCupStanding(XElement b)
        {
            XNamespace ns = "http://xmlsoccer.com/TeamCupStanding";

            return new TeamLeagueStanding
            {
                Team = b.Element(ns + "Team").Value,
                Team_Id = int.Parse(b.Element(ns + "Team_Id").Value),
                Played = b.Element(ns + "Played") != null ? int.Parse(b.Element(ns + "Played").Value) : 0,
                PlayedAtHome =
                    b.Element(ns + "PlayedAtHome") != null ? int.Parse(b.Element(ns + "PlayedAtHome").Value) : 0,
                PlayedAway =
                    b.Element(ns + "PlayedAway") != null ? int.Parse(b.Element(ns + "PlayedAway").Value) : 0,
                Won = b.Element(ns + "Won") != null ? int.Parse(b.Element(ns + "Won").Value) : 0,
                Draw = b.Element(ns + "Draw") != null ? int.Parse(b.Element(ns + "Draw").Value) : 0,
                Lost = b.Element(ns + "Lost") != null ? int.Parse(b.Element(ns + "Lost").Value) : 0,
                NumberOfShots =
                    b.Element(ns + "NumberOfShots") != null
                        ? int.Parse(b.Element(ns + "NumberOfShots").Value)
                        : 0,
                YellowCards =
                    b.Element(ns + "YellowCards") != null ? int.Parse(b.Element(ns + "YellowCards").Value) : 0,
                RedCards = b.Element(ns + "RedCards") != null ? int.Parse(b.Element(ns + "RedCards").Value) : 0,
                Goals_For =
                    b.Element(ns + "Goals_For") != null ? int.Parse(b.Element(ns + "Goals_For").Value) : 0,
                Goals_Against =
                    b.Element(ns + "Goals_Against") != null
                        ? int.Parse(b.Element(ns + "Goals_Against").Value)
                        : 0,
                Goal_Difference =
                    b.Element(ns + "Goal_Difference") != null
                        ? int.Parse(b.Element(ns + "Goal_Difference").Value)
                        : 0,
                Points = b.Element(ns + "Points") != null ? int.Parse(b.Element(ns + "Points").Value) : 0,
                Group_Id = b.Element(ns + "Group_Id") != null ? int.Parse(b.Element(ns + "Group_Id").Value) : 0,
                Group = b.Element(ns + "Group") != null ? b.Element(ns + "Group").Value : null
            };
        }
    }
}