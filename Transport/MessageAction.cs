namespace Transport
{
    public enum MessageAction
    {
        /// <summary>
        /// Ни чего не делать
        /// </summary>
        None,

        /// <summary>
        /// Отменить сообщение
        /// </summary>
        Reject,

        /// <summary>
        /// Подтвердить получение
        /// </summary>
        Ack,
    }
}