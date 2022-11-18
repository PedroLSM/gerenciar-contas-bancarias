export class Utils {
    formatText(text: string): string {
        return text.replace(/(?:\*)(?:(?!\s))((?:(?!\*|\n).)+)(?:\*)/g, '<b>$1</b>')
            .replace(/(?:_)(?:(?!\s))((?:(?!\n|_).)+)(?:_)/g, '<i>$1</i>')
            .replace(/(?:~)(?:(?!\s))((?:(?!\n|~).)+)(?:~)/g, '<s>$1</s>')
            .replace(/(?:--)(?:(?!\s))((?:(?!\n|--).)+)(?:--)/g, '<u>$1</u>')
            .replace(/(?:```)(?:(?!\s))((?:(?!\n|```).)+)(?:```)/g, '<tt>$1</tt>');

        // extra:
        // --For underlined text--
        // ```Monospace font```
    }
}