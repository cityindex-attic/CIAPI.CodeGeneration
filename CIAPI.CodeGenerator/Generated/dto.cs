using System;
namespace CIAPI.DTO
{
	public class AccountInformationResponseDTO
	{
		public string LogonUserName {get; set;}
		public int ClientAccountId {get; set;}
		public string ClientAccountCurrency {get; set;}
		public int AccountOperatorId {get; set;}
		public ApiTradingAccountDTO[] TradingAccounts {get; set;}
		public string PersonalEmailAddress {get; set;}
		public bool HasMultipleEmailAddresses {get; set;}
	}

	public class ApiActiveStopLimitOrderDTO
	{
		public int OrderId {get; set;}
		public int? ParentOrderId {get; set;}
		public int MarketId {get; set;}
		public string MarketName {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal TriggerPrice {get; set;}
		public int TradingAccountId {get; set;}
		public int Type {get; set;}
		public int Applicability {get; set;}
		public DateTime? ExpiryDateTimeUTC {get; set;}
		public string Currency {get; set;}
		public int Status {get; set;}
		public ApiBasicStopLimitOrderDTO StopOrder {get; set;}
		public ApiBasicStopLimitOrderDTO LimitOrder {get; set;}
		public ApiBasicStopLimitOrderDTO OcoOrder {get; set;}
		public DateTime LastChangedDateTimeUTC {get; set;}
	}

	public class ApiBasicStopLimitOrderDTO
	{
		public int OrderId {get; set;}
		public decimal TriggerPrice {get; set;}
		public decimal Quantity {get; set;}
	}

	public class ApiChangePasswordRequestDTO
	{
		public string UserName {get; set;}
		public string Password {get; set;}
		public string NewPassword {get; set;}
	}

	public class ApiChangePasswordResponseDTO
	{
		public bool IsPasswordChanged {get; set;}
	}

	public class ApiClientAccountWatchlistDTO
	{
		public int WatchlistId {get; set;}
		public string WatchlistDescription {get; set;}
		public int DisplayOrder {get; set;}
		public ApiClientAccountWatchlistItemDTO[] Items {get; set;}
	}

	public class ApiClientAccountWatchlistItemDTO
	{
		public int WatchlistId {get; set;}
		public int MarketId {get; set;}
		public int DisplayOrder {get; set;}
	}

	public class ApiClientApplicationMessageTranslationDTO
	{
		public string Key {get; set;}
		public string Value {get; set;}
	}

	public class ApiClientApplicationMessageTranslationRequestDTO
	{
		public int ClientApplicationId {get; set;}
		public int CultureId {get; set;}
		public int AccountOperatorId {get; set;}
		public string[] InterestedTranslationKeys {get; set;}
	}

	public class ApiClientApplicationMessageTranslationResponseDTO
	{
		public ApiClientApplicationMessageTranslationDTO[] TranslationKeyValuePairs {get; set;}
	}

	public class ApiCultureLookupDTO
	{
		public string Code {get; set;}
		public int Id {get; set;}
		public string Description {get; set;}
		public int DisplayOrder {get; set;}
		public int? TranslationTextId {get; set;}
		public string TranslationText {get; set;}
		public bool IsActive {get; set;}
		public bool IsAllowed {get; set;}
	}

	public class ApiDateTimeOffsetDTO
	{
		public DateTime UtcDateTime {get; set;}
		public int OffsetMinutes {get; set;}
	}

	public class ApiDeleteWatchlistRequestDTO
	{
		public int WatchlistId {get; set;}
	}

	public class ApiDeleteWatchlistResponseDTO
	{
		public bool Deleted {get; set;}
	}

	public class ApiErrorResponseDTO
	{
		public int HttpStatus {get; set;}
		public string ErrorMessage {get; set;}
		public int ErrorCode {get; set;}
	}

	public class ApiIfDoneDTO
	{
		public ApiStopLimitOrderDTO Stop {get; set;}
		public ApiStopLimitOrderDTO Limit {get; set;}
	}

	public class ApiIfDoneResponseDTO
	{
		public ApiOrderResponseDTO Stop {get; set;}
		public ApiOrderResponseDTO Limit {get; set;}
	}

	public class ApiLogOffRequestDTO
	{
		public string UserName {get; set;}
		public string Session {get; set;}
	}

	public class ApiLogOffResponseDTO
	{
		public bool LoggedOut {get; set;}
	}

	public class ApiLogOnRequestDTO
	{
		public string UserName {get; set;}
		public string Password {get; set;}
		public string AppKey {get; set;}
		public string AppVersion {get; set;}
		public string AppComments {get; set;}
	}

	public class ApiLogOnResponseDTO
	{
		public string Session {get; set;}
		public bool PasswordChangeRequired {get; set;}
		public bool AllowedAccountOperator {get; set;}
	}

	public class ApiLookupDTO
	{
		public int Id {get; set;}
		public string Description {get; set;}
		public int DisplayOrder {get; set;}
		public int? TranslationTextId {get; set;}
		public string TranslationText {get; set;}
		public bool IsActive {get; set;}
		public bool IsAllowed {get; set;}
	}

	public class ApiLookupResponseDTO
	{
		public int CultureId {get; set;}
		public string LookupEntityName {get; set;}
		public ApiLookupDTO[] ApiLookupDTOList {get; set;}
		public ApiCultureLookupDTO[] ApiCultureLookupDTOList {get; set;}
	}

	public class ApiMarketDTO
	{
		public int MarketId {get; set;}
		public string Name {get; set;}
	}

	public class ApiMarketEodDTO
	{
		public string MarketEodUnit {get; set;}
		public int? MarketEodAmount {get; set;}
	}

	public class ApiMarketInformationDTO
	{
		public int MarketId {get; set;}
		public string Name {get; set;}
		public decimal? MarginFactor {get; set;}
		public decimal? MinMarginFactor {get; set;}
		public int MarginFactorUnits {get; set;}
		public decimal? MaxMarginFactor {get; set;}
		public decimal? MinDistance {get; set;}
		public decimal? WebMinSize {get; set;}
		public decimal? MaxSize {get; set;}
		public bool Market24H {get; set;}
		public int? PriceDecimalPlaces {get; set;}
		public int? DefaultQuoteLength {get; set;}
		public bool TradeOnWeb {get; set;}
		public bool LimitUp {get; set;}
		public bool LimitDown {get; set;}
		public bool LongPositionOnly {get; set;}
		public bool CloseOnly {get; set;}
		public ApiMarketEodDTO[] MarketEod {get; set;}
		public decimal? PriceTolerance {get; set;}
		public int ConvertPriceToPipsMultiplier {get; set;}
		public int MarketSettingsTypeId {get; set;}
		public string MarketSettingsType {get; set;}
		public string MobileShortName {get; set;}
		public string CentralClearingType {get; set;}
		public string CentralClearingTypeDescription {get; set;}
		public int MarketCurrencyId {get; set;}
		public decimal? PhoneMinSize {get; set;}
		public DateTime? DailyFinancingAppliedAtUtc {get; set;}
		public DateTime? NextMarketEodTimeUtc {get; set;}
		public DateTime? TradingStartTimeUtc {get; set;}
		public DateTime? TradingEndTimeUtc {get; set;}
		public ApiTradingDayTimesDTO[] MarketPricingTimes {get; set;}
		public ApiTradingDayTimesDTO[] MarketBreakTimes {get; set;}
		public ApiMarketSpreadDTO[] MarketSpreads {get; set;}
		public decimal? GuaranteedOrderPremium {get; set;}
		public int? GuaranteedOrderPremiumUnits {get; set;}
		public decimal? GuaranteedOrderMinDistance {get; set;}
		public int? GuaranteedOrderMinDistanceUnits {get; set;}
		public decimal? PriceToleranceUnits {get; set;}
		public int MarketTimeZoneOffsetMinutes {get; set;}
		public decimal? BetPer {get; set;}
		public int? MarketUnderlyingTypeId {get; set;}
		public string MarketUnderlyingType {get; set;}
		public DateTime? ExpiryUtc {get; set;}
	}

	public class ApiMarketInformationSaveDTO
	{
		public int MarketId {get; set;}
		public decimal? PriceTolerance {get; set;}
		public bool PriceToleranceIsDirty {get; set;}
		public decimal? MarginFactor {get; set;}
		public bool MarginFactorIsDirty {get; set;}
	}

	public class ApiMarketSpreadDTO
	{
		public DateTime? SpreadTimeUtc {get; set;}
		public decimal Spread {get; set;}
		public int SpreadUnits {get; set;}
	}

	public class ApiMarketTagDTO
	{
		public int MarketTagId {get; set;}
		public string Name {get; set;}
		public int Type {get; set;}
	}

	public class ApiOpenPositionDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string MarketName {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal Price {get; set;}
		public int TradingAccountId {get; set;}
		public string Currency {get; set;}
		public int Status {get; set;}
		public ApiBasicStopLimitOrderDTO StopOrder {get; set;}
		public ApiBasicStopLimitOrderDTO LimitOrder {get; set;}
		public DateTime LastChangedDateTimeUTC {get; set;}
	}

	public class ApiOrderActionResponseDTO
	{
		public int ActionedOrderId {get; set;}
		public int ActioningOrderId {get; set;}
		public decimal Quantity {get; set;}
		public decimal ProfitAndLoss {get; set;}
		public string ProfitAndLossCurrency {get; set;}
		public int OrderActionTypeId {get; set;}
	}

	public class ApiOrderDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal? Price {get; set;}
		public int TradingAccountId {get; set;}
		public int CurrencyId {get; set;}
		public int StatusId {get; set;}
		public int TypeId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public ApiStopLimitOrderDTO OcoOrder {get; set;}
	}

	public class ApiOrderResponseDTO
	{
		public int OrderId {get; set;}
		public int StatusReason {get; set;}
		public int Status {get; set;}
		public int OrderTypeId {get; set;}
		public decimal Price {get; set;}
		public decimal Quantity {get; set;}
		public decimal TriggerPrice {get; set;}
		public decimal CommissionCharge {get; set;}
		public ApiIfDoneResponseDTO[] IfDone {get; set;}
		public decimal GuaranteedPremium {get; set;}
		public ApiOrderResponseDTO OCO {get; set;}
	}

	public class ApiPrimaryMarketTagDTO
	{
		public ApiMarketTagDTO[] Children {get; set;}
		public int MarketTagId {get; set;}
		public string Name {get; set;}
		public int Type {get; set;}
	}

	public class ApiQuoteResponseDTO
	{
		public int QuoteId {get; set;}
		public int Status {get; set;}
		public int StatusReason {get; set;}
	}

	public class ApiSaveAccountInformationRequestDTO
	{
		public string PersonalEmailAddress {get; set;}
		public bool PersonalEmailAddressIsDirty {get; set;}
	}

	public class ApiSaveAccountInformationResponseDTO
	{
	}

	public class ApiSaveMarketInformationResponseDTO
	{
	}

	public class ApiSaveWatchlistRequestDTO
	{
		public ApiClientAccountWatchlistDTO Watchlist {get; set;}
	}

	public class ApiSaveWatchlistResponseDTO
	{
	}

	public class ApiSimulateOrderResponseDTO
	{
		public int StatusReason {get; set;}
		public int Status {get; set;}
	}

	public class ApiStopLimitOrderDTO
	{
		public bool Guaranteed {get; set;}
		public decimal TriggerPrice {get; set;}
		public DateTime? ExpiryDateTimeUTC {get; set;}
		public string Applicability {get; set;}
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal? Price {get; set;}
		public int TradingAccountId {get; set;}
		public int CurrencyId {get; set;}
		public int StatusId {get; set;}
		public int TypeId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public ApiStopLimitOrderDTO OcoOrder {get; set;}
	}

	public class ApiStopLimitOrderHistoryDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string MarketName {get; set;}
		public string Direction {get; set;}
		public decimal OriginalQuantity {get; set;}
		public decimal? Price {get; set;}
		public decimal TriggerPrice {get; set;}
		public int TradingAccountId {get; set;}
		public int TypeId {get; set;}
		public int OrderApplicabilityId {get; set;}
		public string Currency {get; set;}
		public int StatusId {get; set;}
		public DateTime LastChangedDateTimeUtc {get; set;}
		public DateTime CreatedDateTimeUtc {get; set;}
	}

	public class ApiStopLimitResponseDTO
	{
		public int OrderId {get; set;}
		public int StatusReason {get; set;}
		public int Status {get; set;}
		public int OrderTypeId {get; set;}
		public decimal Price {get; set;}
		public decimal Quantity {get; set;}
		public decimal TriggerPrice {get; set;}
		public decimal CommissionCharge {get; set;}
		public ApiIfDoneResponseDTO[] IfDone {get; set;}
		public decimal GuaranteedPremium {get; set;}
		public ApiOrderResponseDTO OCO {get; set;}
	}

	public class ApiTradeHistoryDTO
	{
		public int OrderId {get; set;}
		public int[] OpeningOrderIds {get; set;}
		public int MarketId {get; set;}
		public string MarketName {get; set;}
		public string Direction {get; set;}
		public decimal OriginalQuantity {get; set;}
		public decimal Quantity {get; set;}
		public decimal Price {get; set;}
		public int TradingAccountId {get; set;}
		public string Currency {get; set;}
		public decimal? RealisedPnl {get; set;}
		public string RealisedPnlCurrency {get; set;}
		public DateTime LastChangedDateTimeUtc {get; set;}
		public DateTime ExecutedDateTimeUtc {get; set;}
	}

	public class ApiTradeOrderDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal? Price {get; set;}
		public int TradingAccountId {get; set;}
		public int CurrencyId {get; set;}
		public int StatusId {get; set;}
		public int TypeId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public ApiStopLimitOrderDTO OcoOrder {get; set;}
	}

	public class ApiTradeOrderResponseDTO
	{
		public int Status {get; set;}
		public int StatusReason {get; set;}
		public int OrderId {get; set;}
		public ApiOrderResponseDTO[] Orders {get; set;}
		public ApiQuoteResponseDTO Quote {get; set;}
		public ApiOrderActionResponseDTO[] Actions {get; set;}
	}

	public class ApiTradingAccountDTO
	{
		public int TradingAccountId {get; set;}
		public string TradingAccountCode {get; set;}
		public string TradingAccountStatus {get; set;}
		public string TradingAccountType {get; set;}
	}

	public class ApiTradingDayTimesDTO
	{
		public int DayOfWeek {get; set;}
		public ApiDateTimeOffsetDTO StartTimeUtc {get; set;}
		public ApiDateTimeOffsetDTO EndTimeUtc {get; set;}
	}

	public class CancelOrderRequestDTO
	{
		public int OrderId {get; set;}
		public int TradingAccountId {get; set;}
	}

	public class ClientAccountMarginDTO
	{
		public decimal Cash {get; set;}
		public decimal Margin {get; set;}
		public decimal MarginIndicator {get; set;}
		public decimal NetEquity {get; set;}
		public decimal OpenTradeEquity {get; set;}
		public decimal TradeableFunds {get; set;}
		public decimal PendingFunds {get; set;}
		public decimal TradingResource {get; set;}
		public decimal TotalMarginRequirement {get; set;}
		public int CurrencyId {get; set;}
		public string CurrencyISO {get; set;}
	}

	public class ClientPreferenceKeyDTO
	{
		public string Key {get; set;}
		public string Value {get; set;}
	}

	public class ClientPreferenceRequestDTO
	{
		public string Key {get; set;}
	}

	public class DeleteWatchlistItemRequestDTO
	{
		public int ParentWatchlistDisplayOrderId {get; set;}
		public int MarketId {get; set;}
	}

	public enum ErrorCode
	{
		NoError = 0,
		Forbidden = 403,
		InternalServerError = 500,
		InvalidParameterType = 4000,
		ParameterMissing = 4001,
		InvalidParameterValue = 4002,
		InvalidJsonRequest = 4003,
		InvalidJsonRequestCaseFormat = 4004,
		InvalidCredentials = 4010,
		InvalidSession = 4011,
		NoDataAvailable = 5001,
		Throttling = 5002,
	}

	public class GetActiveStopLimitOrderResponseDTO
	{
		public ApiActiveStopLimitOrderDTO ActiveStopLimitOrder {get; set;}
	}

	public class GetClientPreferenceResponseDTO
	{
		public ClientPreferenceKeyDTO ClientPreference {get; set;}
	}

	public class GetITFinanceSessionServiceResponseDTO
	{
		public string ITFinanceSessionKey {get; set;}
	}

	public class GetKeyListClientPreferenceResponseDTO
	{
		public string[] ClientPreferenceKeys {get; set;}
	}

	public class GetListClientPreferenceResponseDTO
	{
		public ClientPreferenceKeyDTO[] ClientPreferences {get; set;}
	}

	public class GetMarketInformationResponseDTO
	{
		public ApiMarketInformationDTO MarketInformation {get; set;}
	}

	public class GetMessagePopupResponseDTO
	{
		public bool AskForClientApproval {get; set;}
		public string Message {get; set;}
	}

	public class GetNewsDetailResponseDTO
	{
		public NewsDetailDTO NewsDetail {get; set;}
	}

	public class GetOpenPositionResponseDTO
	{
		public ApiOpenPositionDTO OpenPosition {get; set;}
	}

	public class GetOrderResponseDTO
	{
		public ApiTradeOrderDTO TradeOrder {get; set;}
		public ApiStopLimitOrderDTO StopLimitOrder {get; set;}
	}

	public class GetPriceBarResponseDTO
	{
		public PriceBarDTO[] PriceBars {get; set;}
		public PriceBarDTO PartialPriceBar {get; set;}
	}

	public class GetPriceTickResponseDTO
	{
		public PriceTickDTO[] PriceTicks {get; set;}
	}

	public class GetVersionInformationResponseDTO
	{
		public string MinimumRequiredVersion {get; set;}
		public string LatestVersion {get; set;}
		public string UpgradeUrl {get; set;}
	}

	public class InsertWatchlistItemRequestDTO
	{
		public int ParentWatchlistDisplayOrderId {get; set;}
		public int MarketId {get; set;}
	}

	public class ListActiveStopLimitOrderResponseDTO
	{
		public ApiActiveStopLimitOrderDTO[] ActiveStopLimitOrders {get; set;}
	}

	public class ListCfdMarketsResponseDTO
	{
		public ApiMarketDTO[] Markets {get; set;}
	}

	public class ListMarketInformationRequestDTO
	{
		public int[] MarketIds {get; set;}
	}

	public class ListMarketInformationResponseDTO
	{
		public ApiMarketInformationDTO[] MarketInformation {get; set;}
	}

	public class ListMarketInformationSearchResponseDTO
	{
		public ApiMarketInformationDTO[] MarketInformation {get; set;}
	}

	public class ListMarketSearchResponseDTO
	{
		public ApiMarketDTO[] Markets {get; set;}
	}

	public class ListNewsHeadlinesResponseDTO
	{
		public NewsDTO[] Headlines {get; set;}
	}

	public class ListOpenPositionsResponseDTO
	{
		public ApiOpenPositionDTO[] OpenPositions {get; set;}
	}

	public class ListSpreadMarketsResponseDTO
	{
		public ApiMarketDTO[] Markets {get; set;}
	}

	public class ListStopLimitOrderHistoryResponseDTO
	{
		public ApiStopLimitOrderHistoryDTO[] StopLimitOrderHistory {get; set;}
	}

	public class ListTradeHistoryResponseDTO
	{
		public ApiTradeHistoryDTO[] TradeHistory {get; set;}
		public ApiTradeHistoryDTO[] SupplementalOpenOrders {get; set;}
	}

	public class ListWatchlistResponseDTO
	{
		public int ClientAccountId {get; set;}
		public ApiClientAccountWatchlistDTO[] ClientAccountWatchlists {get; set;}
	}

	public class MarketInformationSearchWithTagsResponseDTO
	{
		public ApiMarketDTO[] Markets {get; set;}
		public ApiMarketTagDTO[] Tags {get; set;}
	}

	public class MarketInformationTagLookupResponseDTO
	{
		public ApiPrimaryMarketTagDTO[] Tags {get; set;}
	}

	public class NewsDetailDTO
	{
		public string Story {get; set;}
		public int StoryId {get; set;}
		public string Headline {get; set;}
		public DateTime PublishDate {get; set;}
	}

	public class NewsDTO
	{
		public int StoryId {get; set;}
		public string Headline {get; set;}
		public DateTime PublishDate {get; set;}
	}

	public class NewStopLimitOrderRequestDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Currency {get; set;}
		public bool AutoRollover {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal BidPrice {get; set;}
		public decimal OfferPrice {get; set;}
		public string AuditId {get; set;}
		public int TradingAccountId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public NewStopLimitOrderRequestDTO OcoOrder {get; set;}
		public string Applicability {get; set;}
		public DateTime? ExpiryDateTimeUTC {get; set;}
		public bool Guaranteed {get; set;}
		public decimal TriggerPrice {get; set;}
	}

	public class NewTradeOrderRequestDTO
	{
		public int MarketId {get; set;}
		public string Currency {get; set;}
		public bool AutoRollover {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public int? QuoteId {get; set;}
		public decimal BidPrice {get; set;}
		public decimal OfferPrice {get; set;}
		public string AuditId {get; set;}
		public int TradingAccountId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public int[] Close {get; set;}
	}

	public class OrderDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public int ClientAccountId {get; set;}
		public int TradingAccountId {get; set;}
		public int CurrencyId {get; set;}
		public string CurrencyISO {get; set;}
		public int Direction {get; set;}
		public bool AutoRollover {get; set;}
		public decimal ExecutionPrice {get; set;}
		public DateTime LastChangedTime {get; set;}
		public decimal OpenPrice {get; set;}
		public DateTime OriginalLastChangedDateTime {get; set;}
		public decimal OriginalQuantity {get; set;}
		public int PositionMethodId {get; set;}
		public decimal Quantity {get; set;}
		public string Type {get; set;}
		public string Status {get; set;}
		public int ReasonId {get; set;}
	}

	public class PriceBarDTO
	{
		public DateTime BarDate {get; set;}
		public decimal Open {get; set;}
		public decimal High {get; set;}
		public decimal Low {get; set;}
		public decimal Close {get; set;}
	}

	public class PriceDTO
	{
		public int MarketId {get; set;}
		public DateTime TickDate {get; set;}
		public decimal Bid {get; set;}
		public decimal Offer {get; set;}
		public decimal Price {get; set;}
		public decimal High {get; set;}
		public decimal Low {get; set;}
		public decimal Change {get; set;}
		public int Direction {get; set;}
		public string AuditId {get; set;}
		public int StatusSummary {get; set;}
	}

	public class PriceTickDTO
	{
		public DateTime TickDate {get; set;}
		public decimal Price {get; set;}
	}

	public class QuoteDTO
	{
		public int QuoteId {get; set;}
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public decimal BidPrice {get; set;}
		public decimal BidAdjust {get; set;}
		public decimal OfferPrice {get; set;}
		public decimal OfferAdjust {get; set;}
		public decimal Quantity {get; set;}
		public int CurrencyId {get; set;}
		public int StatusId {get; set;}
		public int TypeId {get; set;}
		public DateTime RequestDateTimeUTC {get; set;}
		public DateTime ApprovalDateTimeUTC {get; set;}
		public int BreathTimeSecs {get; set;}
		public bool IsOversize {get; set;}
		public int ReasonId {get; set;}
		public int TradingAccountId {get; set;}
	}

	public class SaveClientPreferenceRequestDTO
	{
		public ClientPreferenceKeyDTO ClientPreference {get; set;}
	}

	public class SaveMarketInformationRequestDTO
	{
		public ApiMarketInformationSaveDTO[] MarketInformation {get; set;}
		public int TradingAccountId {get; set;}
	}

	public class SystemStatusDTO
	{
		public string StatusMessage {get; set;}
	}

	public class SystemStatusRequestDTO
	{
		public string TestDepth {get; set;}
	}

	public class TradeMarginDTO
	{
		public int ClientAccountId {get; set;}
		public int DirectionId {get; set;}
		public decimal MarginRequirementConverted {get; set;}
		public int MarginRequirementConvertedCurrencyId {get; set;}
		public string MarginRequirementConvertedCurrencyISOCode {get; set;}
		public int MarketId {get; set;}
		public int MarketTypeId {get; set;}
		public decimal Multiplier {get; set;}
		public int OrderId {get; set;}
		public decimal OTEConverted {get; set;}
		public int OTEConvertedCurrencyId {get; set;}
		public string OTEConvertedCurrencyISOCode {get; set;}
		public decimal PriceCalculatedAt {get; set;}
		public decimal PriceTakenAt {get; set;}
		public decimal Quantity {get; set;}
	}

	public class UpdateDeleteClientPreferenceResponseDTO
	{
		public bool Successful {get; set;}
	}

	public class UpdateStopLimitOrderRequestDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Currency {get; set;}
		public bool AutoRollover {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public decimal BidPrice {get; set;}
		public decimal OfferPrice {get; set;}
		public string AuditId {get; set;}
		public int TradingAccountId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public NewStopLimitOrderRequestDTO OcoOrder {get; set;}
		public string Applicability {get; set;}
		public DateTime? ExpiryDateTimeUTC {get; set;}
		public bool Guaranteed {get; set;}
		public decimal TriggerPrice {get; set;}
	}

	public class UpdateTradeOrderRequestDTO
	{
		public int OrderId {get; set;}
		public int MarketId {get; set;}
		public string Currency {get; set;}
		public bool AutoRollover {get; set;}
		public string Direction {get; set;}
		public decimal Quantity {get; set;}
		public int? QuoteId {get; set;}
		public decimal BidPrice {get; set;}
		public decimal OfferPrice {get; set;}
		public string AuditId {get; set;}
		public int TradingAccountId {get; set;}
		public ApiIfDoneDTO[] IfDone {get; set;}
		public int[] Close {get; set;}
	}

	public class UpdateWatchlistDisplayOrderRequestDTO
	{
		public int[] NewDisplayOrderIdSequence {get; set;}
	}

}
