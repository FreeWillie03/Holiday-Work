using ValrCore.Models;


public class Account{
    public Balance[] balances {get;}
    public TransactionHistory[] History {get;}
}

public class Balance{
    public Currency currency {get;}
    public Wallet available{get;}
    public Wallet reserved {get;}
    private float total = available + reserved;
    public Wallet Total {get;
        set{total;}
    }
    
}

public class TransactionHistory{
    public TransactionType Types {get;}
    public Transaction Transactions {get;}
}
public class TransactionType{
    public string type{get;set;}
    public string description {get;set;}
}
public class Transaction{
    public Currency debitCurrency {get;}
    public Currency debitValue {get;}
    public Currency creditCurrency{get;}
    public Currency creditValue{get;}
    public Currency feeCurrrency {get;}
    public Currency feeValue{get;}
    public TimeStamp eventAt{get;}
    public AdditionalInfo additional {get;}
}
public class AdditionalInfo {
    public int costPerCoin {get;} // Not sure if int or double
    public string costPerCoinSymbol {get;}
    public Currency currencyPairSymbol {get;}
    public string orderId {get;}
}

public class TradeHistory{
    public int price {get;}
    public float quantity {get;}
    public Currency currencyPair {get;}
    public TimeStamp tradedAt {get;}
    public string side {get;}
    public int tradeId {get;}
}