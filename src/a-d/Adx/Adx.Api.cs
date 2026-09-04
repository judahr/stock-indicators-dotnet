namespace Skender.Stock.Indicators;

// AVERAGE DIRECTIONAL INDEX (API)
public static partial class Indicator
{
    // SERIES, from TQuote
    /// <include file='./info.xml' path='info/*' />
    ///
    public static IEnumerable<AdxResult> GetAdx<TQuote>(
        this IEnumerable<TQuote> quotes,
        int lookbackPeriods = 14)
        where TQuote : IQuote => quotes
            .ToQuoteD()
            .CalcAdx(lookbackPeriods);

    // SERIES, from QuoteD (double precision, no conversion)
    /// <summary>
    /// Gets the ADX series directly from double-precision quotes, without conversion.
    /// </summary>
    /// <param name="quotes">Historical price quotes, in double precision.</param>
    /// <param name="lookbackPeriods">Number of periods in the lookback window.</param>
    /// <returns>Time series of ADX and Plus/Minus Directional values.</returns>
    /// <exception cref="ArgumentNullException">Quotes cannot be null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Invalid parameter value provided.</exception>
    public static List<AdxResult> GetAdx(
        this List<QuoteD> quotes,
        int lookbackPeriods = 14)
    {
        if (quotes is null)
        {
            throw new ArgumentNullException(nameof(quotes));
        }

        return quotes.CalcAdx(lookbackPeriods);
    }
}
