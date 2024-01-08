const zasadyWymagane = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  }
]
const zasadyHaslo = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  },
  (wartosc) => {
    if (wartosc.toLowerCase() !== wartosc && /\d/.test(wartosc) && wartosc.length >= 8) return true
    else return 'Hasło musi zawierać przynajmniej 8 znaków, małą literę, dużą literę i cyfrę'
  }
]
const zasadyLogin = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  },
  (wartosc) => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(wartosc) || 'Nieprawidłowy e-mail'
]
const zasadyImie = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  },
  (wartosc) => {
    if (
      wartosc[0].toLowerCase() !== wartosc[0] &&
      wartosc.slice(1).toLowerCase() === wartosc.slice(1)
    )
      return true
    else return 'Powinno zaczynać się od wielkiej litery'
  },
  (wartosc) => {
    if (
      !/\d/.test(wartosc) &&
      !/[^a-zA-Z0-9\u0118\u0119\u00F3\u00D3\u0141\u0142\u0104\u0105\u017B\u017C\u017A\u0179\u0106\u0107\u0143\u0144\u015A\u015B]/.test(
        wartosc
      ) &&
      !/_/.test(wartosc)
    )
      return true
    else return 'Może zawierać tylko litery'
  }
]
const zasadyPesel = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  },
  (wartosc) => {
    if (!/\D/.test(wartosc) && wartosc.length === 11) return true
    else return 'Pesel musi składać się z 11 cyfr'
  }
]
const zasadyNumer = [
  (wartosc) => {
    if (wartosc) return true
    else return 'Pole jest wymagane'
  },
  (wartosc) => {
    if (!/\D/.test(wartosc) && wartosc.length === 9) return true
    else return 'Numer telefonu musi składać się z 9 cyfr'
  }
]
export { zasadyHaslo, zasadyLogin, zasadyImie, zasadyNumer, zasadyPesel, zasadyWymagane }
