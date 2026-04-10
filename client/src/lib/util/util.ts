import { format, type DateArg } from "date-fns";
import { de } from "date-fns/locale/de";

export function formatDate(date: DateArg<Date>): string {
    return format(date, 'dd MMM yyyy, HH:mm', { locale: de });
}
