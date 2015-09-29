using cisseniorproject.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentManager
/// 
/// Written By Craig Smith 9/17/15
/// 
/// Business Layer to access Payment Information datalayer
/// </summary>
namespace cisseniorproject.payment
{


    public class PaymentManager
    {
        public PaymentManager()
        {
            
        }



        public static bool addCreditCard(string username, string creditCardType, string creditCardNumber, string creditCardCity, 
            string creditCardState, DateTime creditCardExpDate, string securitCode)
        {
            UserDAO userDataLayer = new UserDAO();
            User user = userDataLayer.getUserDetails(username);
            
            PaymentInformation newCreditCard = new PaymentInformation();
            newCreditCard.setUser(user);
            newCreditCard.setCreditCardType(creditCardType);
            newCreditCard.setCreditCardNumber(creditCardNumber);
            newCreditCard.setCity(creditCardCity);
            newCreditCard.setState(creditCardState);
            newCreditCard.setCardExpDated(creditCardExpDate);
            newCreditCard.setSecurityCode(securitCode);

            PaymentInformationDAO Paymentdatalayer = new PaymentInformationDAO();
            Boolean success = Paymentdatalayer.addNewCreditCard(newCreditCard);

            return success;
        }

        public static List<PaymentInformation> getUserCreditCards(string username)
        {
            UserDAO userDataLayer = new UserDAO();
            User user = userDataLayer.getUserDetails(username);

            PaymentInformationDAO paymentInfoDatalayer = new PaymentInformationDAO();
            List<PaymentInformation> userPaymentInfo = paymentInfoDatalayer.getUserPaymentInfo(user);

            return userPaymentInfo;
        }

        public static PaymentInformation getUserCreditCard(int paymentId)
        {
            UserDAO userDataLayer = new UserDAO();
            
            PaymentInformationDAO dataLayer = new PaymentInformationDAO();
            PaymentInformation userCreditCard = dataLayer.getUserCreditCard(paymentId);

            return userCreditCard;
        }
    }
}