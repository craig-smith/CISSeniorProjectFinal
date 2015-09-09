using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentInformation
/// 
/// Data Object used to hold information about payment information
/// 
/// Written by Craig Smith 9/8/15
/// </summary>
public class PaymentInformation
{
    private int paymentInformationId;
    private User user; 
    private String creditCardType;
    private String creditCardNumber;
    private String city;
    private String state;
    private DateTime cardExpDate;
    private String securityCode;

	public PaymentInformation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public PaymentInformation(int paymentInformationId, User user, String creditCardType, String creditCardNumber, String city, String state, DateTime cardExpDate, String securityCode)
    {
        this.paymentInformationId = paymentInformationId;
        this.user = user;
        this.creditCardType = creditCardType;
        this.creditCardNumber = creditCardNumber;
        this.city = city;
        this.state = state;
        this.cardExpDate = cardExpDate;
        this.securityCode = securityCode;
    }

    public int getPaymentInformationId()
    {
        return this.paymentInformationId;
    }
    public void setPaymentInformationId(int paymentInformationId)
    {
        this.paymentInformationId = paymentInformationId;
    }

    public User getUser()
    {
        return this.user;
    }
    public void setUser(User user)
    {
        this.user = user;
    }

    public String getCreditCardType()
    {
        return this.creditCardType;
    }
    public void setCreditCardType()
    {
        this.creditCardType = creditCardType;
    }

    public String getCreditCardNumber()
    {
        return this.creditCardNumber;
    }
    public void setCreditCardNumber(String creditCardNumber)
    {
        this.creditCardNumber = creditCardNumber;
    }

    public String getCity()
    {
        return this.city;
    }
    public void setCity(String city)
    {
        this.city = city;
    }

    public String getState()
    {
        return this.state;
    }
    public void setState(String state)
    {
        this.state = state;
    }

    public DateTime getCardExpDate()
    {
        return this.cardExpDate;
    }
    public void setCardExpDated(DateTime cardExpDate)
    {
        this.cardExpDate = cardExpDate;
    }

    public String getSecurityCode()
    {
        return this.securityCode;
    }
    public void setSecurityCode(String securityCode)
    {
        this.securityCode = securityCode;
    }
}