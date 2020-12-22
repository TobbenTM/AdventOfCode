using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day22
    {
        public static int SolvePart1(string input)
        {
            var playerDecks = input
                .Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(player => new Queue<int>(player.Split('\n').Skip(1).Select(int.Parse)))
                .ToArray();
            while (playerDecks.All(deck => deck.Count > 0))
            {
                var cardA = playerDecks.First().Dequeue();
                var cardB = playerDecks.Last().Dequeue();
                if (cardA > cardB)
                {
                    playerDecks.First().Enqueue(cardA);
                    playerDecks.First().Enqueue(cardB);
                }
                else
                {
                    playerDecks.Last().Enqueue(cardB);
                    playerDecks.Last().Enqueue(cardA);
                }
            }
            var winningDeck = playerDecks
                .Single(deck => deck.Count > 0);
            return winningDeck
                .Select((card, index) => card * (winningDeck.Count - index))
                .Sum();
        }

        public static int SolvePart2(string input)
        {
            var playerDecks = input
                .Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(player => new Queue<int>(player.Split('\n').Skip(1).Select(int.Parse)))
                .ToArray();
            var winner = PlayGame(playerDecks);
            return playerDecks[winner]
                .Select((card, index) => card * (playerDecks[winner].Count - index))
                .Sum();
        }

        private static int PlayGame(Queue<int>[] playerDecks)
        {
            var history = new HashSet<string>();
            while (playerDecks.All(deck => deck.Count > 0))
            {
                var signature = string.Join("vs", playerDecks.Select(deck => string.Join(",", deck)));
                if (history.Contains(signature))
                {
                    return 0;
                }
                history.Add(signature);
                var (winningPlayer, cards) = PlayRound(playerDecks);
                foreach (var card in cards)
                {
                    playerDecks[winningPlayer].Enqueue(card);
                }
            }
            return playerDecks.First().Count > 0 ? 0 : 1;
        }

        private static (int winningPlayer, int[] cards) PlayRound(Queue<int>[] playerDecks)
        {
            var cardA = playerDecks.First().Dequeue();
            var cardB = playerDecks.Last().Dequeue();
            if (playerDecks.First().Count >= cardA && playerDecks.Last().Count >= cardB)
            {
                var winningPlayer = PlayGame(new[]
                {
                    new Queue<int>(playerDecks.First().Take(cardA)),
                    new Queue<int>(playerDecks.Last().Take(cardB))
                });
                return (winningPlayer, winningPlayer == 0 ? new[] { cardA, cardB } : new[] { cardB, cardA });
            }
            if (cardA > cardB)
            {
                return (0, new[] { cardA, cardB });
            }
            else
            {
                return (1, new[] { cardB, cardA });
            }
        }
    }
}
