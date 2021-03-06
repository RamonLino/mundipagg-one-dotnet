﻿using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients;
using GatewayApiClient.ResourceClients.Interfaces;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public class GatewayServiceClient : IGatewayServiceClient {

        #region Recursos utilizados na SDK

        private ISaleResource _sale;
        /// <summary>
        /// Recurso de venda
        /// </summary>
        public ISaleResource Sale { get { return _sale; } }

        private ICreditCardResource _creditCard;
        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        public ICreditCardResource CreditCard { get { return _creditCard; } }

        private IBuyerResource _buyer;
        /// <summary>
        /// Recurso buyer
        /// </summary>
        public IBuyerResource Buyer { get { return _buyer; } }

        private ITokenResource _token;
        /// <summary>
        /// Recurso de Token
        /// </summary>
        public ITokenResource Token { get { return _token; } }

        #endregion

        public GatewayServiceClient() : this(Guid.Empty, null, null) { }
        public GatewayServiceClient(Guid merchantKey) : this(merchantKey, null, null) { }
        public GatewayServiceClient(Guid merchantKey, Uri hostUri) : this(merchantKey, hostUri, null) { }
        public GatewayServiceClient(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) {

            this._sale = new SaleResource(merchantKey, hostUri, customHeaders);
            this._creditCard = new CreditCardResource(merchantKey, hostUri, customHeaders);
            this._buyer = new BuyerResource(merchantKey, hostUri, customHeaders);
            this._token = new TokenResource(merchantKey, hostUri, customHeaders);
        }
    }
}
