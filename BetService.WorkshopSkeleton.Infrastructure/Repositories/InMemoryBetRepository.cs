using Microsoft.Extensions.Caching.Memory;

namespace BetService.WorkshopSkeleton.Infrastructure.Repositories
{
	public class InMemoryBetRepository
	{
		private readonly IMemoryCache _memoryCache;

		public InMemoryBetRepository(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public async Task AddAsync(Bet bet, CancellationToken cancellationToken)
		{
			_memoryCache.Set(bet.Id, bet);
			await Task.CompletedTask;
		}

		public async Task<Bet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			_memoryCache.TryGetValue(id, out Bet? bet);
			return await Task.FromResult(bet);
		}
	}
}
