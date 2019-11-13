

public class Crypto{
    public class DepositeAddress{
        public Currency currency {get;}
        public string address {get;}
    }
    public class WithdrawalInfo{
        public Currency currency {get;}
        public float minimumWithdrawAmount {get;}
        public bool isActive {get;}
        public float withdrawCost {get;}
        public bool supportsPaymentReference {get;}
    }
}
public class Fiat{

}