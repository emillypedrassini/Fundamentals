namespace AccessModifiers
{
	public class GoldCustomer : Customer
	{
		public void OfferVouchar()
		{
			//...

			this.Delete(1);
		}
	}
}
