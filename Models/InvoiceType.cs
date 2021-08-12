namespace Models
{
    public enum InvoiceType
    {
        E_INVOICE = 1,
        RECURRING_INVOICE,
        PAST_DUE_INVOICE,
        FINAL_INVOICE,
        INTERIM_INVOICE,
        PRO_FORMA_INVOICE,
        EXPENSE_REPORT,
        TIMESHEET_INVOICE,
        COMMERCIAL_INVOICE,
        MIXED_INVOICE,
        DEBIT_INVOICE,
        CREDIT_INVOICE,
        STANDARD_INVOICE
    }
}