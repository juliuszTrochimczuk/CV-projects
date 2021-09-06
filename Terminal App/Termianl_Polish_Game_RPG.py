import random

class Gracz:
    def __init__(self, Pancerz):
        self.MaksHP = 100
        self.Pancerz = Pancerz
        self.AktualneHP = 100

    def DodawaniePancerza(self, Ilosc):
        self.Pancerz = self.Pancerz + Ilosc

    def DodawanieHP(self, Ilosc):
        self.MaksHP = self.MaksHP + Ilosc

    def OtrzymywanieObrazen(self, Ilosc):
        Ilosc = Ilosc - self.Pancerz
        if Ilosc > 0:
            self.AktualneHP = self.AktualneHP - Ilosc

    def Leczenie(self, Ilosc):
        self.AktualneHP = self.AktualneHP + Ilosc
        if (self.AktualneHP > self.MaksHP):
            self.AktualneHP = self.MaksHP

    def Informacje(self):
        return {"Maksymalne zdrowie":self.MaksHP, "Aktualne zdrowie":self.AktualneHP, "Pancerz":self.Pancerz}

class Wojownik(Gracz):
    def __init__(self):
        super().__init__(2)

    def Atakowanie(self, Parametr):
        self.Blok = False
        if Parametr == 1:   #Walniecie Tarcza
            self.Atak = random.randint(7, 15)
            Ogloszenie = random.randint(0, 100)
            if Ogloszenie >= 50:
                self.Blok = True
        elif Parametr == 2:     #Lekkie ciecie mieczem
            self.Atak = random.randint(10, 15)
        else:       #Mocne ciecie mieczem
            self.Atak = random.randint(5, 25)
        return self.Atak, self.Blok

class Lucznik(Gracz):
    def __init__(self):
       super().__init__(1)

    def Atakowanie(self, Parametr):
        self.Przebicie = False
        if Parametr == 1: #Walniecie lukiem
            self.Atak = random.randint(7, 16)
        elif Parametr == 2: #Strzelenie z luku z ostrym grotem
            self.Atak = random.randint(10, 18)
            Przebicie = random.randint(0, 100)
            if Przebicie >= 50:
                self.Przebicie = True
        else:   #Strzelenie z luku z zaczarowanym grotem
            self.Atak = random.randint(12, 18)
        return self.Atak, self.Przebicie

class Mag(Gracz):
    def __init__(self):
        super().__init__(0)

    def Atakowanie(self, Parametr):
        self.Dezorientacja = False
        if Parametr == 1: #Kula ognia
            self.Atak = random.randint(15, 25)
        elif Parametr == 2: #Wybuch energii
            self.Atak = random.randint(10, 30)
        else:   #Pulapka umyslu
            self.Atak = random.randint(6, 10)
            Dezorientacja = random.randint(0, 100)
            if Dezorientacja >= 50:
                self.Dezorientacja = True
        return self.Atak, self.Dezorientacja

class Przeciwnik:
    def __init__(self, Hp=100, Pancerz=0, Poziom=1):
        self.Hp = Hp
        self.Pancerz = Pancerz
        self.Poziom = Poziom

    def Atakowanie(self):
        RodzajAtaku = random.randint(1, 3)
        if RodzajAtaku == 1:
            self.Atak = random.randint(4*self.Poziom, 15*self.Poziom)
        elif RodzajAtaku == 2:
            self.Atak = random.randint(10*self.Poziom, 12*self.Poziom)
        else:
            self.Atak = random.randint(9*self.Poziom, 15*self.Poziom)
        return self.Atak

    def OtrzymywanieObrazen(self, Ilosc):
        Ilosc = Ilosc - self.Pancerz
        if Ilosc > 0:
            self.Hp = self.Hp - Ilosc

    def Informacje(self):
        return {"Zdrowie":self.Hp, "Panerz":self.Pancerz}


def Walka(Gracz, Przeciwnik):
    if WyborKlasy == 1: #Gracz jest wojownikiem
        while Przeciwnik.Hp > 0:
            print("Ty: ", Gracz.Informacje())
            print("Przeciwnik: ", Przeciwnik.Informacje())
            print("1 - Walniecie Tarcza, szansa na ogluszenie; 2 - Lekkie ciecie mieczem; 3 - Mocne ciecie mieczem")
            WyborAtaku = int(input())
            while WyborAtaku != 1 and WyborAtaku != 2 and WyborAtaku != 3:
                print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Walniecie lukiem; 2 - Strzelenie z luku z ostrym grotem, szansa na przebicie; 3 - Strzelenie z luku z zaczarowanym grotem")
                WyborAtaku = int(input())
            AtakGracza = Gracz.Atakowanie(WyborAtaku) #Gracz atakuje
            print("Twoj atak wyniosl: ", AtakGracza[0])
            if WyborAtaku == 1:
                if Gracz.Blok == True:
                    print("Czy ogluszyles przeciwnika: ", AtakGracza[1])
                else:
                    print("Czy ogluszyles przeciwnika: ", AtakGracza[1])
            Przeciwnik.OtrzymywanieObrazen(AtakGracza[0]) #Przeciwnik obrywa
            if Przeciwnik.Hp <= 0:
                print("Wygrales")
                return Nagrody(Gracz)
            AtakPrzeciwnika = Przeciwnik.Atakowanie() #Przeciwnik atakuje
            print("Przeciwnik atakuje za: ", AtakPrzeciwnika)
            if Gracz.Blok == True:
                Gracz.Pancerz *= 2
                Gracz.OtrzymywanieObrazen(AtakPrzeciwnika) #Gracz obrywa kiedy mial Blok (2*Pancerz)
                Gracz.Pancerz //= 2
            else:
                Gracz.OtrzymywanieObrazen(AtakPrzeciwnika)  #Gracz obrywa kiedy nie mial Blok
            if Gracz.AktualneHP <= 0:
                return 0
    elif WyborKlasy == 2: #Gracz jest lucznikiem
        while Przeciwnik.Hp > 0:
            print("Ty: ", Gracz.Informacje())
            print("Przeciwnik: ", Przeciwnik.Informacje())
            print("1 - Walniecie lukiem; 2 - Strzelenie z luku z ostrym grotem, szansa na przebicie; 3 - Strzelenie z luku z zaczarowanym grotem")
            WyborAtaku = int(input())
            while WyborAtaku != 1 and WyborAtaku != 2 and WyborAtaku != 3:
                print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Walniecie lukiem; 2 - Strzelenie z luku z ostrym grotem, szansa na przebicie; 3 - Strzelenie z luku z zaczarowanym grotem")
                WyborAtaku = int(input())
            AtakGracza = Gracz.Atakowanie(WyborAtaku)   #Gracz atakuje
            print("Twoj atak wyniosl: ", AtakGracza[0])
            if WyborAtaku == 2:
                if Gracz.Przebicie == True:
                    print("Czy strzala przebila przeciwnika: ", AtakGracza[1])
                    Przeciwnik.OtrzymywanieObrazen(AtakGracza[0] * 2)   #Przeciwnik obrywa z przybiciem (AtakGracza[1] - Wartosc ataku * 2 - wartosc premii)
                else:
                    print("Czy strzala przebila przeciwnika: ", AtakGracza[1])
                    Przeciwnik.OtrzymywanieObrazen(AtakGracza[0])   #Przeciwnik obrywa bez przybicia
            else:
                Przeciwnik.OtrzymywanieObrazen(AtakGracza[0])   #Przeciwnik obrywa jesli wyborem gracza bylo cos innego niz opcja z przybiciem
            if Przeciwnik.Hp <= 0:
                print("Wygrales")
                return Nagrody(Gracz)
            AtakPrzeciwnika = Przeciwnik.Atakowanie()
            print("Przeciwnik atakuje za: ", AtakPrzeciwnika)
            Gracz.OtrzymywanieObrazen(AtakPrzeciwnika)
            if Gracz.AktualneHP <= 0:
                print("Koniec Gry - Przegrales")
                return 0
    else: #Gracz jest magiem
        while Przeciwnik.Hp > 0:
            print("Ty: ", Gracz.Informacje())
            print("Przeciwnik: ", Przeciwnik.Informacje())
            print("1 - Kula ognia; 2 - Wybuch energii; 3 - Pulapka umyslu, szansa na dezorientacje")
            WyborAtaku = int(input())
            while WyborAtaku != 1 and WyborAtaku != 2 and WyborAtaku != 3:
                print(
                    "Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Kula ognia; 2 - Wybuch energii; 3 - Pulapka umyslu, szansa na dezorientacje")
                WyborAtaku = int(input())
            AtakGracza = Gracz.Atakowanie(WyborAtaku)
            print("Twoj atak wyniosl: ", AtakGracza[0])
            if WyborAtaku == 3:
                print("Czy przeciwnik jest zdezorientowany: ", AtakGracza[1])
            Przeciwnik.OtrzymywanieObrazen(AtakGracza[0])
            if Przeciwnik.Hp <= 0:
                print("Wygrales")
                return Nagrody(Gracz)
            AtakPrzeciwnika = Przeciwnik.Atakowanie()
            print("Przeciwnik atakuje za: ", AtakPrzeciwnika)
            if Gracz.Dezorientacja == True:
                Gracz.OtrzymywanieObrazen(0)
            else:
                Gracz.OtrzymywanieObrazen(AtakPrzeciwnika)
            if Gracz.AktualneHP <= 0:
                print("Koniec gry - Przegrana")
                return 0


def Nagrody(Gracz):
    Los = random.randint(0, 100)
    if Los <= 50:
        Ilosc = random.randint(0, 5)
        print("Udalo ci sie znalezc kawalek pancerza. Czy chcesz go wziac dla siebie? 1 - Tak; 2 - Nie")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Tak; 2 - Nie")
            Wybor = int(input())
        if Wybor == 1:
            Gracz.DodawaniePancerza(Ilosc)
        return 0
    elif Los > 50 and Los <= 99:
        Ilosc = random.randint(15, 25)
        print("Znajdujesz bandaze i mikstury. Czy chcesz sie opatrzyc i wyleczyc? 1 - Tak; 2 - Nie")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Tak; 2 - Nie")
            Wybor = int(input())
        if Wybor == 1:
            Gracz.Leczenie(Ilosc)
        return 0
    else:
        Ilosc = random.randint(0, 5)
        print("Udalo ci sie znalezc czerwony krysztal. Czujesz w nim ogromna energie zyciowa. Czy chcesz go uzyc? 1 - Tak; 2 - Nie")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Tak; 2 - Nie")
            Wybor = int(input())
        if Wybor == 1:
            Gracz.DodawanieHP(Ilosc)
            Gracz.Leczenie(Gracz.MaksHP)
        return 0

def StartGryIWyborPostaci():
    print("UWAGA! W tej grze uzywane sa opcje tylko liczbowe. Uzycie jakiej kolwiek litery, moze spowodowac blad gry i zatrzymanie jej dzialania. Dziekujemy za uwage i milej gry :)")
    print("Witaj w niesamowitym uniwersum Rise of the Horizon. Czy chcesz rozpoczac swa przygode po tym swiecie? 1 - Rozpocznij gre")
    Wybor = int(input())
    while Wybor != 1:
        print("Nie rozumiem co chcesz powiedziec. Jesli chcesz zagrac wcisnij 1, jesli nie to zamknij terminal")
        Wybor = int(input())
    print("Znakomicie. Jaka klasa chcesz grac? 1 - Wojownik; 2 - Lucznik; 3 - Mag")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2 and Wybor != 3:
        print("Nie rozumiem co masz na mysli. Jaka klasa chcesz zagrac? 1 - Wojownik; 2 - Lucznik; 3 - Mag")
        Wybor = int(input())
    return Wybor

def PoczatekGryKarczma():
    print("Znajdujesz sie w przytulnej karczmie na poludniu krolestwa Turdrajan, nieopodal Wielkiego Miasta Kupieckiego. Zmeczony poprzednia wyprawa raczysz sie piwem.")
    print("Cieplo w kominku ogrzewa twe zmeczone cialo od podrozy. Spokuj to jest to czego ci bylo potrzeba")
    print("Pijac kolejne lyki trunku dostrzegasz jak pewien mezczyzna podchodzi do twego stolika. Szybko blokujesz krzeslo noga, jednak on dzieki swej magi teleportuje krzeslo za siebie i spokojnie zasiada u twego boku. Nieznajomy mezczyzna proponuje ci zlecenie na pewna zwierzyne. Znajduje sie ona nieopodal poludniowego Krolestwa Krasnoludow. 1 - Przyjmujesz zlecenie; 2 - Mowisz nieznajomemu ze nie jestes zainteresowany zleceniem")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc?  1 - Przyjmujesz zlecenie; 2 - Mowisz nieznajomemu ze nie jestes zainteresowany zleceniem")
    if Wybor == 1:
        print("Nieznajomy usmiechanl sie lekko. Poprosil bramana o piwo dla siebie i przysiadl do twego stolika")
        Wybor = 1
        return Wybor
    else:
        print("Nieznajomy odchodzi. Jednak nie widac po nim zalu. Konczysz swe piwo i wychodzisz z karczmy. Lekki wiatr przypomina ci stare, dobre czasy kiedy to nie musiales sie o nic martwic. Wyjmujesz z kieszeni list. Dobrze wiesz co jest tam napisane jednak czytasz jeszcze raz. Mowa tam o twym bracie ktory jest w tarapatach i potzrebuje pomocy. Chowasz lisy do kieszeni i wsiadasz na konia, by udac sie w pordroz")
        Wybor = 2
        return Wybor


def Zlecenie(): #5 rozdzialow 1 - Rozmowa z magiem; 2 - Przeszukanie miejsce zywienia bestii; 3 - Odnalezienie leza bestii; 4 - Walka z besita; 5 - Konfrontacja z magiem
    print("Po kilku glebszych lykach dopytujesz sie maga dokladnie o zlecenie. Ten wciaz z tym samym usmiechem prosi barmana o dolewke.")   #Rozdzial 1
    print("W koncu zaczyna mowic. Jest to bestia nocna. Calymi dniamy spi w swojej pieczarze, zas nocami poluje.  Znalezlismy gdzie sie pozywia, jednak lokalizacji leza wciaz nie znamy. Nagle z kieszeni wyjmuje mape i ci pokazuje. Jest na niej zaznaczony znak X, i kolko wokol niego. Mag mowi o tym jak obserwowali bestie.")
    print("Na samym poczatku zywil sie jedynie owadami, rybami i krolikami. Jednak z czasem zaczela pozerac owce, krowy i konie. To nie oznaczalo nic dobrego.")
    print("1 - Spytaj sie jak dlugo je duze zwierzeta; 2 - Spytaj sie od kiedy ja obserwujesz i z kim")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Spytaj sie jak dlugo je duze zwierzeta; 2 - Spytaj sie od kiedy ja obserwujesz i z kim")
        Wybor = int(input())
    if Wybor == 1:
        print("Od kilku miesiecy, zaczyna denerwowac to wiesniakow. I dlatego przyjechalem do ciebie, bys zaja sie ta bestia.")
    else:
        print("Od lat praktycznie. Stad wiem co jadla. Inny problem, ze zawsze to robilem z swoim asystentem. Ten jednak pewnego wieczoru zostal dluzej by zanotowac inne zachowania w nocy, a bestia go zjadla. Nastpenego dnia widzialem tyko strzepki ubran i pozostawione notatki. Najwyrazniej bestia nie byla zainteresowana nauka.")
    print("Po dluzszym namysle masz pewne przepuszczenia o jaka bestie moze chodzic, jednak nic nie moze byc pewne do poki nie zobaczysz miejsce ataku bestii.")
    print("Zanim jednak to, to zaplata. Mag moze zaoferowac 100 zlotych monet. 1 - To za malo; 2 - Przyjmuje")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Spytaj sie jak dlugo je duze zwierzeta; 2 - Spytaj sie od kiedy ja obserwujesz i z kim.")
        Wybor = int(input())
    if Wybor == 1:
        print("Mag ci odpowiada: Dam duzo, tak duzo jak wielka gora zlota, jednak na dzien dzisiejszy moge ci zaoferowac jedynie to.")
    else:
        print("Mag znow robi swoj charakterystyczny usmiech i wyciaga reke na znak osiagniecia umowy.")
    print("Wstajesz od stolu by przyszykowac sie na podroz. Mag mowi, ze po wykonanej robocie spotkacie sie w Wielkim Miescie Kupcow w jego domu i przekazal kolejna mape. Teraz znak X oznaczal lokalizacje domu maga.")
    print("Wsiadles na konia i wyruszyles w podroz. Pod nosem modliles sie by zlecenie bylo tak latwe jak sie na poczatku wydawalo.")
    print("Kiedy przyjechales na wyznaczone miejsce, byl juz swit. W calej potedze slonca zobaczyles jego zerowisko. To bylo cos okropnego. Na ziemi slady szponow, na drzewach polamane galezie. i zwloki zwierzat. Nagle zza skarpy wyskoczyly wyglodniale wilki i przywodca watachy na czele. Widac, ze to miejsce nie mialo jednego zywiciela.")    #Rozdzial 2
    PrzeciwnikGry = Przeciwnik()
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("Po pokonaniu alfy, reszta watachy sie rozbiegla. Zdali sobie sprawe ze nie moge sie z toba rownac.")
    print("Po kilku ciezszych oddechach zwrociles uwage na zwloki krowy. Podszedles do nich i przykleknales. Jeszcze cieple. Musialy byc tu z tej nocy. Uwaznie ogladasz dziure w brzuchu")
    print("Jest ona wielka. Z ciala krowy wylaza flaki, jednak brakuje watroby i zoladka. Dotykasz jej wnetrza jednak nagle z ciala ulatuja ciemne opary. Szybko sie odsuwasz i zakrywasz twarz. Zadne znane ci dobrze stworzenie na swiecie nie wytwarza czegos takiego.")
    print("Wtem ciemne opary uformowaly potwora. Ciemna istote. Sywmi szponami cienia rzucila sie na ciebie w agonalnym krzyku")
    PrzeciwnikGry = Przeciwnik(50, 0, 2)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("Duch zamienil sie w krysztal. Czujesz w nim moc zycia. Czy chcesz go przyjac? 1 - Przyjmij go; 2 - Zostaw")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Przyjmij go; 2 - Zostaw")
        Wybor = int(input())
    if Wybor == 1:
        Gracz.DodawanieHP(10)
        Gracz.Leczenie(Gracz.MaksHP)
    print("Po pokonaniu potwora juz zaczynasz rozumiec z czym masz do czynienia. Tutaj chodzi o czarna magie. Demony.")
    print("Trzeba go zabic zanim wyrzadzi wiecej szkod na swiecie. Jednak wciaz nie wiesz gdzie demon ma swoje leze. Przypominasz sobie, ze potwor poluje tylko noca. Jesli uda ci sie zaobserwowac skad nadlatuje na zerowisko moze bedziesz w stanie usatlic gdzie ma leze.")
    print("W pewnej chwili slyszysz jak okoliczny wiesniak jedzie na wozie. Przypominasz sobie, ze demon zywil sie w pobliskiej wiosce. Moze ten wiesniak wie gdzie demon ma leze.")
    print("Jaka jest twoja decyzja? 1 - Zaczekaj do zmroku i zobacz demona; 2 - Zapytaj wiesniaka")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print(
            "Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Zaczekaj do zmroku i zobacz demona; 2 - Zapytaj wiesniaka")
        Wybor = int(input())
    if Wybor == 1:
        print("Przycupnales przy pobliskim polamanym drzewie i przysnales.")
        print("W srodku nocy obudzil cie lopotanie skrzydel. Widzisz go. Majestatyczny, wielki jak piec koni. Szpony ma jek dziesiec mieczy. Nagle demon wydal z sobie dzwiek. Jego krzyk brzmial jak krzyk tysiaca potepionych dusz. Schowales sie za krzakami by cie nie zauwazyl. Potwor wyladowal z wielka moca, niszczac okoliczne zycie pod stopami. O ile to mozna bylo nazwac stopami")
        print("Konskie kopyta ktore mialy wlosy i skore, ktora reagowala na cieplo i wieczorne zimno. Demon obserwuje okolice. Szuka pozywienia. Niestety nie moze nic znalezc i leci dalej. W kierunku pobliskiej wioski.")
        print("Zauwazasz, ze jest to idealna pora na zbadanie jego leza. Potwor cala noc bedzie polowa, wiec masz cala noc by tam wejsc i znalezc cos przydatnego w pokonaniu jego.")
    else:
        print("Podchodzisz do wiesniaka, ten lekko przestraszony twoim widokiem zatrzymuje sie. Zapytujesz go o rzekomego potwora, ktory napada na okoliczne wsie.")
        print("Wiesniak opowiada ci o skrzydlatej bestii, ktora jest wielka jak piec koni. Zeby ma takie jak sto mieczy, a pazurami moglaby niszczyc gory. Opis lekko cie przestraszyl, jednak dobrze wiesz, ze prosci ludzie wola czasem dodac cos od siebie. Moze jednak nie tym razem.")
        print("Pytasz sie o legowisko bestii. Wiesniak ci z checia odpowiada, jednak dodaje, ze jest to dosc niebezpieczna okolica. To dla ciebie nic nowego.")
        print("Wiesz gdzie potwor, ma swe leze. Wiesz jak wyglada, z opisu wynikaloby ze to demon. Jednak dawno zaden demon nie byl w naszym swiecie. Wiesz rowniez, ze w nocy wylatuje na lowy. Trzeba zaczekac na noc i sprawdzic jego leze. Moze tam znadziesz cos przydatnego")
        print("Podczas nocnej jazdy ujzales z gory przelatujaca bestie. To nie byla bestia. Wszystko co wiesniak ci opowiedzial bylo prawda. Najwidoczniej niedlugo przyjdzie ci sie zmierzyc z demonem we wlasnej osobie. Musisz sie skupic, tylko strach moze cie zabic.")
        print("Jadac przez ciemny las zauwazyles, pary oczu. Zwierzecych oczu. Kolejny raz wilki chcialy przetestowac cie w walce. Pokaz ic co potrafisz")
        PrzeciwnikGry = Przeciwnik()
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Kiedy udalo ci sie przepedzic kolejna watache pora na wejscie do leza demona.")
    print("To co wszyscy okreslali lezem, bylo tak naprawde dziura w ziemi. Kilka lisci bylo ulozonych w kolku. Co moglo znaczyc o inteligencji demona. Jednak to co zwraca najbardziej u ciebie uwage to oddalony daleko przedmiot")   #Rozdzial 3
    print("Tak jakby to bylo dla niego najcenniejsze i musi za wszelka cene bronic. Kiedy zajrzałeś do środka zobaczyłeś małe czarne pudełko. Nigdy czegoś takiego nie widziałeś. Mroczna energia, aż z niego wypływała. To pewnie było źródło energii tego demona.")
    print("Kiedy dotknąłeś pudełka wszystko stało się nagle czarne. Stoisz posrodku niczego, a do okola widzisz pustke. Nagle poczules podmuch wiatru i uderzenie. Nagle udezrzenie zza plecow. Przygotowany do walki nie wiesz co sie dzieje")
    print("Nagle w ciemnosci zauwazasz cien. Istote pustki i magii demonicznej. Najwidoczniej nie ma dobrych zamiarow")
    PrzeciwnikGry = Przeciwnik(50)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("Po jej pokonaniu pojawia sie przeblysk przeszlosci. Widzisz maga i jego pomocnika. Mowia o stworzeniu poteznego narzedzia. Wtem kolejna zjawia sie pojawia i cie atakuje")
    PrzeciwnikGry = Przeciwnik(50, 0, 1)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("I kolejna wizja. Teraz mag stoi nad lustrem i bieze do reki zwykle pudelko na zabawki. Mowi cos pod nosem jednak nie jestes w stanie uslyszec i chwile pozniej pudelko zmienia sie w to ktore ukrywa demon")
    print("Wtem z nikad pojawia sie kolejna zjawa")
    PrzeciwnikGry = Przeciwnik(50, 0, 1)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("Zdajesz juz sobie sprawe kto przywolal demona do naszego swiata. Jednak nie wiesz jak opuscic to miejsce. W glowie zaczyna ci szumic. Slyszysz jeki tysiecy zamordowanych przez tego potwora. W ostatecznej chwili pojawia sie. Najwiekszy z cieni. Jesli go pokonasz, moze uda ci sie stad wydostac.")
    PrzeciwnikGry = Przeciwnik(100, 1, 1)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("Wtem wrociles na polane, gdzie bylo leze demona. W reku trzymasz kostke. Jednym sprawnym ruchem miesni, niszczysz ja na drobne kawaleczki. Nawet nie czules by kostka stawiala ci opor. Jakby sama chciala zostac zniszczona")
    print("Z okruchow kostki utworzyl sie mroczny krzysztal zycia. Czujesz jego energie i wiesz, ze jego moc pozwoli ci pokonac demona. 1 - Przymij go; 2 - Zostaw")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Przyjmij go; 2 - Zostaw")
        Wybor = int(input())
    if Wybor == 1:
        Gracz.DodawanieHP(15)
        Gracz.Leczenie(Gracz.MaksHP)
    else:
        print("Lepiej nie zaczynac z mroczna magia, bo mozna zle skonczyc.")
    print("Patrzysz w niebo, swit. Demon niedlugo wroci do swego leza, a ty jestes gotowy stawic mu czola.")    #Rozdzial 4
    print("Nagle go dostrzegasz. Majestatycznego swiece smierci. Cos jednak jest nie tak. Demond dynamicznie zmienia poziom lotu i nie jest w stanie sie utrzymac.")
    print("Wali w calej sily w okoliczny las i wywraca kilka drzew. Czyli zniszczenie kostki podzialalo. Teraz jest oslabiony")
    print("Jednak nie wystarczy oslabic demona by go zabic. Wciaz byl niesamowicie silny. Kilkoma susami przemierzy setki metrow i nim dokonales mrugniecia stales z nim oko w oko.")
    PrzeciwnikGry = Przeciwnik(150, 2, 2)
    Walka(Gracz, PrzeciwnikGry)
    if Gracz.AktualneHP <= 0:
        return 0
    print("To byla ciezka walka. Demon lezy ciezko dychajac od odniesionych ran. Zamierzasz zadac ostateczny cios, jednak ten prosi. Prosi bys go wysluchal. Czy to kolejne halucynacje? Czy to jakis podstep?")
    print("Demon zaczyna mowic po ludzku. Mowi o tym, ze mag go zdradzil. Obiecal mu potege i wladze. Bogactwa jakich zaden czlowiek nie dostapi. Mialem tylko mu pomoc w eksperymencie.")
    print("Demon mowi bys nie ufal magowi. Wiele razy probowal i dopiero teraz mu sie udalo. Jesli mu pomorzesz nie wiadomo ilu jeszcze niewinnych, omamionych jego magia i obietnicami zabije")
    print("Ostatnie zyczenie demona, bylo. By smierc byla szybka. I tak tez uczyniles.")
    print("Jesli slowa demona sa prawdziwe rzucaja nowe swiatlo na sprawe. To by tez tlumaczylo wizje w pudelku.")
    print("Jesli jednak sa one nie prawdziwe to moze ktos inny stac za tymi rzeczami")
    print("Ulamales zab demona, na znak ukonczonego zlecenia i udajesz sie do Wielkiego Miasta Kupieckiego by zrozumiec o co tu biega.")
    print("rzy zwlokach demona udalo ci sie znalezc krysztal zycia. 1 - Przyjmij go; 2 - Zostaw")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Przyjmij go; 2 - Zostaw")
        Wybor = int(input())
    if Wybor == 1:
        Gracz.DodawanieHP(15)
        Gracz.Leczenie(Gracz.MaksHP)
    print("Cala podroz minela ci szybko. Caly czas rozmyslales o tym co powiedzial ci ten demon. Wciaz nie jestes pewien czy to prawda. ")   #Rozdzial 5
    print("Stoisz przy domu maga, pukasz do jego drzwi jednak nie widzisz, zadnej reakcji. Moze maga nie ma w domu.")
    print("Nagle drzwi sie otwieraja a ty wchodzisz do domu. Dom pusty jakby duchy w nim mieszkaly.")
    print("Tajemniczy glos w twojej glowie sugeruje bys zszedl do piwnicy. Tak wlasnie postepujesz i twoim oczom ukazje sie pracowania maga.")
    print("Pelna roznych filek, eliksirow, magicznych przedmiotow.")
    print("Stoisz oko w oko z magiem. Ten zapytuje cie czy misja sie udala. Odpowiadasz twierdzaco i pokazujesz mu ulamany zab demona.")
    print("Mezczyzna kiwa glowa z aprobata. Pokazuje miejsce gdzie znajdziesz zloto i mozesz odejsc. 1 - Zacznij pytac o demona; 2 - Wez zloto")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Zacznij pytac o demona; 2 - Wez zloto")
        Wybor = int(input())
    if Wybor == 1:
        print("Mag radzici bys nie drazyl tematu. Ten szelmancki usmiech zniknal z jego twarzy dawno temu, zastapiony czystym profesjonalizmem.")
        print("Co robisz? 1 - Nie odpuszczaj; 2 - Odpusc, wez zloto i uciekaj")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Nie odpuszczaj; 2 - Odpusc, wez zloto i uciekaj")
            Wybor = int(input())
        if Wybor == 1:
            print("Mag mowi, iz postapiles bardzo zle. Przyznaje sie do popelnionych zbrodni i wyjasnia je tak: Widziales je. Potezne stworzenia mogace zabijac wszystko. One istnieja. Jesli sami nie stworzymy sobie armi demonow one zabija nas szybciej. Robie to... Dla wspolnego dobra")
            PrzeciwnikGry = Przeciwnik(75, 1, 3)
            Walka(Gracz, PrzeciwnikGry)
            if Gracz.AktualneHP <= 0:
                return 0
            print("Walka byla trudna. Jednak udalo ci sie wygrac. Odchodzisz w chwale i zwyciestwie.")
            print("Koniec Gry - Wygrana! Gratulujemy ci przejscia tej gry. Sa rowniez inne drogi, ktorymi fabula moze sie potoczyc, zachecamy do ponownego zagrania. A raczej do kolejnego zagrania :)")
            return 0
        else:
            print("Podchodisz do skrytki ustawionej na krancu laboratorium. Nagle czujesz jakis bol w glowie. Padasz nie wiedzac co sie dzieje. W tem nie spodziewanie czujesz jak miecz przebija ci brzuch, a wokol ciebie zaczyna pojawiac sie czarna magia")
            print("Mag mowi zachwyconym glosem: To ja go zabilem, przemienilem w demona. Ty jednak jestes silniejszy, moze ty niedasz pochlanoc sie czarnej magii. Wtem zaczyna wypowiadac slowa pradawnego zaklecia, a ty czujesz jak twoje cialo umiera. Twoj dawny ja umiera. Rodzi sie")
            print("Demon")
            print("Koniec Gry! Gratulujemy ci przejscia tej gry. Sa rowniez inne drogi, ktorymi fabula moze sie potoczyc, zachecamy do ponownego zagrania. A raczej do kolejnego zagrania :)")
            return 0
    else:
        print("Podchodisz do skrytki ustawionej na krancu laboratorium. Nagle czujesz jakis bol w glowie. Padasz nie wiedzac co sie dzieje. W tem nie spodziewanie czujesz jak miecz przebija ci brzuch, a wokol ciebie zaczyna pojawiac sie czarna magia")
        print("Mag mowi zachwyconym glosem: To ja go zabilem, przemienilem w demona. Ty jednak jestes silniejszy, moze ty niedasz pochlanoc sie czarnej magii. Wtem zaczyna wypowiadac slowa pradawnego zaklecia, a ty czujesz jak twoje cialo umiera. Twoj dawny ja umiera. Rodzi sie")
        print("Demon")
        print("Koniec Gry! Gratulujemy ci przejscia tej gry. Sa rowniez inne drogi, ktorymi fabula moze sie potoczyc, zachecamy do ponownego zagrania. A raczej do kolejnego zagrania :)")
        return 0


def Brat(): #6 rozdzialow 1 - Przyjazd do miasta; 2 - Karczma 3 - Odnalezienie Brata; 4 - Walka z syndykatem; 5 - Opuszczenie miasta; 6 - Rozlaka z bratem
    print("Blask ksiezyca oswietla twa droge. Mimo zmeczenia nie zatrzymujesz sie. Jesli syndykat zabral sie do niego. Nigdy sobie tego nie wybaczysz. Zaczynasz sobie przypominac jak obiecales bratu sie nim opiekowac. Od dzis poki smierc mnie nie zabierze. Przypominasz sobie rowniez jego placz kiedy wyjzdzales w podroz. Mial zaledwie dwanascie lat") #Rozdzial 1
    print("Droga sie nagle rozwidla. Jedna trasa prowadzi na znany dobrze trakt. Druga moze okazac sie krotsza, jednak prowadzi przez niebezpieczny, ciemny las. Ktora wybierasz? 1 - trakt; 2 - las")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - trakt; 2 - las")
        Wybor = int(input())
    if Wybor == 1:
        print("Wjezdzajac na trakt zaczynasz czuc won Wielkiego Miasta Kupieckiego. Kupcy ktorzy sie przepychaja na wozach by jak najszybciej rozlozyc swoj towar i zaczac przyciagac klientow. Zawsze czules cos do tego miasta. Czy to wspomnienia z dziecinstwa? Czy najlepsze wino w tej czesci krolestw ludzkich?")
        print("W pewnym momencie zauwazasz kupca, ktory zostaje napadniety przez rabusiow. 1 - Postanawiasz ingerowac; 2 - Postanawiasz nie ingerowac")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Postanawiasz ingerowac; 2 - Postanawiasz nie ingerowac")
            Wybor = int(input())
        if Wybor == 1:
            PrzeciwnikGry = Przeciwnik()
            Walka(Gracz, PrzeciwnikGry)
            if Gracz.AktualneHP <= 0:
                return 0
            print("Kupiec jest ci wdzieczny za twa pomoc. W ramach podziekowania chce ci oddac swoj najcenniejszy towar. Kupiec wyjmuje z kieszenie mala skrzynke, otwiera ja kluczem i twoim oczom ukazuje sie bardzo zadki krysztal zycia. 1 - Wez go; 2 - Zostaw kupcowi")
            Wybor = int(input())
            while Wybor != 1 and Wybor != 2:
                print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Wez go; 2 - Zostaw kupcowi")
                Wybor = int(input())
            if Wybor == 1:
                Gracz.DodawanieHP(5)
                Gracz.Leczenie(Gracz.MaksHP)
            else:
                print("Kupiec dziekuje za twa dobroc i czyste serce. Wraca na swoj pozow i z szczesciem jedzie do miasta. Zas ty wracasz na konia i kontynuujesz swa podroz")
        else:
            print("Zlodzieje obrabowali kupca i uciekli z jego zlotem. Miasto najwiekszego handlu nie dla takich co nie umieja zadbac o siebie i ty to dobrze wiesz. Sam tego doswiadczyles")
        print("Po kilku godzinach drogi wjezdzasz przez majestatyczna brame glowna. Tak wielka jak same mury miasta. Wladze specjalnie ja powiekszyly bo w poprzedniej nie miescily sie wszystkie wozy kupiecki na raz, co tworzylo wiele stresu u kupcow i mniej zysku dla rady, a zysk... Jest najwazniejszy")
    else:
        print("Nie mozesz stracic ani chwili. Syndykaty to bandy okrutnikow. W ich szeregach znajduja sie mordercy, najlepszi zlodzieje i niekiedy magowie. Przypominasz sobie moment kiedy twoj brat opuscil syndykat. Moze teraz chcieli sie zemsic za to, ze ich zdradzil")
        print("Nagle twoj kon staje deba. Tracisz nad nim kontrole i spadasz z siodla. Zdezorientowany nie wiesz co moglo wystraszyc konia, jednak wtem widzisz co. Wielki niedzwiedz staje na twej drodze i raczej nie wyglada jakby chcial sie dogadac Wyjscie jest tylko jedno")
        PrzeciwnikGry = Przeciwnik(125, 1)
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Walka byla trudna jednak udalo ci sie wygrac. Przywolujesz konia gwizdnieciem i wracasz w swa podroz. Zaciekawiony myslisz czy jednak zle wybrales droge. Szybko rozwiewasz watpliwosci kiedy twoim oczom ukazuje sie miasto i jego malo majestatyczna brama boczna.")
        print("Straznicy nawet nie reaguja na twa obecnosc pograzeni w blogim snie.")
    print("Wielkie Miasto Kupieckie. Nawet w nocy czujesz jak te miasto tetni zyciem. Pokazy magiczne, stoiska kupcow i szaleni prorocy gloszacy smierc gatunku ludzkiego i przybycie demonow.")
    print("Te miasto nigdy sie nie zmienia. Nawet dwadziescia lat temu wciaz bylo takie same. No moze domownicy sie zmieniaja ale to wciaz te same domy. Dachy domow po ktorych biegales kiedy byles maly.")
    print("Wyjmujesz swoj list by wrocic do poszukiwan. W nim jest napisane, ze twoj brat postara sie przebywac w karczmie Dziki Jelen, tak dlugo jak bedzie w stanie. I oto jest twoj kolejny cel podrozy")
    print("Jak na karczme znajdujaca sie w srodku miasta Dziki Jelen wygladal jakby znajdowal sie w srodku dziczy. Miejsce dla koni, duzo zieleni wokol, cala karczma wykonana z drewna niz z kamienia. Po tylu latach wedrowek ten widok zdziwil cie. Wchodzac do karczmy podszedles do baru poprosic o piwo.")    #Rozdzial 2
    print("Barman wygladal na chetnego do rozmowy. 1 -  Porozmawiaj z barmanem; 2 - Pij piwo w spokoju")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Porozmawiaj z barmanem; 2 - Pij piwo w spokoju")
        Wybor = int(input())
    if Wybor == 1:
        print("Zapytujesz Barmana o twego brata. Opisujesz jego wyglad i cechy charakterystyczne by odroznic go od innych gosci. Barman sobie przypomina takiego goscia i opowiada jak siedzial kilka dni i czekal az ktos przyjedzie. Czujesz zawod w sercu bo wiesz ze czekal na ciebie.")
        print("Barman dodaje, ze widzial jak ktos z syndykatu porwal go. Niestety nie mogl zauwazyc twarzy jednak widzial symbol na pancerzu i jest pewien, ze to syndykat. Wiesz, ze osoby ktore zadarly z syndykatem zabiraja tylko w jedno miejsce i dobrze wiesz gdzie ono sie znajduje")
        print("Po wysluchaniu rozmowy z barmanem dziekujesz mu za pomod, placisz za trunek i wychodzisz")
    else:
        print("W pewnym momencie do karczmy wchodzi trzech zakapturzonych mezczyzn. Siadaja przy stole nieopodal ciebie, zamawiaja dwa piwa i zaczyanaja gadac. Spokojnie pijac przysluchujesz sie rozmowie.")
        print("Mezczyzni rozmawiaja o chlopaku ktory nie splacil dlugu i trzeba bylo zrobic z nim pozadek. Na pewno chodzi o twojego brata, a jesli tak to oznaczaloby, ze wciaz zyje. Syndykat nigdy szybko nie zabija. Oni wola patrzec jak cierpisz by smierc byla aktem laski.")
        print("Korci cie by pojsc do nich i porozmawiac w troche bardziej meskim tonie. Nagle patrzysz na barmana, ktory kiwaniem glowy odradza bys tego robil. 1 - Rozpocznij walke w karczmie; 2 - Zaczekaj az mezczyzni wyjda")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Rozpocznij walke w karczmie; 2 - Zaczekaj az mezczyzni wyjda")
            Wybor = int(input())
        if Wybor == 1:
            print("Ostrzezenie bermana nie przemawia do ciebie. Szybko wyciagasz za bron i zabijasz jednego z mezczyzn, drugiego ciezka reka oszolamiasz, zas ostatni zdarzyl wyciagnac miecz i jest gotowy na pojedynek")
            PrzeciwnikGry = Przeciwnik()
            Walka(Gracz, PrzeciwnikGry)
            if Gracz.AktualneHP <= 0:
                return 0
            print("Po wygranej walce wracasz do mezczyzny ktory lezy oszolomiony na podlodze. Chwytasz go za pancerz i szarpiesz tak, ze odzyskal przytomnosc. Zapytujesz o swego brata, zas ten odpowiada ze wzieli go do opuszczonej fabryki lodzi by porozmawiac.")
        else:
            print("Posluchawszy sie Barmana dokonczyles piwo i wraz z mezczyznami wyszedles na podworko. Tam szybkim ruchem zamordowales dwoch, a ostatni nie zdazyl zareagowac. Niczym zmija podbiegasz do zlodzieja i go przesluchujesz.")
            print("Ten mowi o starej fabryce lodzi i ze tam rozmawiaja z jednym takim co jak szef mowi, nie splacil dlugu")
    print("Znasz juz swoj cel. Czas dotrzymac danego slowa i uwolnic brata od syndykatu.")  #Rozdzial 3
    print("Wsiadasz na konia i jedziesz do opuszczonej fabryki lodzi. Pierwszej fabryki w miescie i poczatku handlu miasta, ktore z niego zyje. Niestety przez okolicznego krakena, ktory zyl w Glebokim Kanale fabryka zostala opuszczona. Kraken wkrotce pozniej zostal pokonany przez wielkiego maga jednak ludzie nie wrocili")
    print("I tak przez lata fabryka stala pusta az syndykat zaczal ja wykorzystywac jako miejsce do trzymania, nazwijmy to, problematycznych ludzi. Taki tez okazal sie twoj brat po zrezygnowaniu z dalszej pracy dla syndykatu.")
    print("Byliscie w tym niezli. Bardzo niezli. Wykonywaliscie najciezsze zlecenia, okrywaliscie sie najwieksza chwala w syndykacie. Oczywiscie nie kazde zlecenie wykonywaliscie razem. Brudna robote i najbardziej platna, wykonywales sam. Bales sie by twoj brat nie stal sie tak okropny jak ty byles.")
    print("Co jednak mogles zrobic. Byliscie jedynie dziecmi ulicy, pozostawione na los swiata")
    print("W koncu dojezdzasz do fabryki. Postanawiasz sie tam zakrasc. Przchodzisz przez zawalone belki, obok scian wypelnionych mchem. Znajdujesz w podlodze platforme, ktora mozna otworzyc. Okazuje sie to podziemne wejscie na teretorium syndykatu. Schodzac coraz bardziej w glab zauwazasz pewna osoby przypieta do krzesla. Ma zawiazane oczy i knebel w ustach. Nad nim stoi mag, ktory w dloni trzyma ogien. Oraz mezczyzne, ktory trzyma sztylet.")
    print("Obaj napastnicy rozmawiaja z soba i mowia jakie potforne rzeczy zamierzaja zrobic ofiarze. 1 - Postanawiasz zareagowac; 2 - Postanawiasz czekac")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Postanawiasz zareagowac; 2 - Postanawiasz czekac")
        Wybor = int(input())
    if Wybor == 1:
        print("Podbiegasz do napastnikow. Jednego walnisz z piesci tak, ze ten pada. Mag zas strzelil z kuli ognia. Dzieki szybkiej reakcji udalo ci sie go ominac i zaczyna sie walka")
        PrzeciwnikGry = Przeciwnik(75, 0, 2)
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Podchodzisz do wieznia. Zdejmujesz mu knebel. Ten dziekuje ci z calych sil. Ropoznajesz glos, jednak zeby sie upewnic zdejmujesz huste z oczu. Tak to on. Udalo ci sie znalezc brata. Kiedy spojrzeliscie sobie w oczy. Poplakaliscie sie i przytuliliscie. W koncu wiesz ze jest caly, ze dotrzymales przysiegi.")
        print("Widac bylo ze go torturowali. Na ciele mial wiele ran, cietych i jedna wielka sliwe pod okiem")
        print("Podajesz bratu sztylet i pytasz czy sobie poradzi. Ten z pewnoscia siebie odpowiada ze tak i teraz pora na ucieczke z tego miejsca.")
    else:
        print("Napastnik z sztyletem podchodzi do wieznia i zdejmuje mu huste i knebel. Rozpoznajesz go. To twoj brat. Napastnik pyta sie o ostatnie jego slowa. Ten odpowia: Obys zginl w piekle ty skur... I rzuca sie na napastnika, wyrywa mu sztylet i wbija prosto w gardlo. Podbiegasz by mu pomoc. Jednak juz jest po wszystkim. Nawet nie wiesz kiedy mag lezal na podlodze z sztyletem w piersi, a napastnik, ktory jeszcze wczesniej mial sztylet w gardle teraz lezal na podlodze przypalony")
        print("Spokojnie podchodzisz do brata. Ten dynamicznie sie odwaraca w twoja strone i przeciera oczy. Nagle z lzami w oczach i usciemechem na twarzy podbiega do ciebie i zaczyna sie przytulac. Mimo, ze byl wyszkolony z bliska zoabczyles rany ktorych odniosl. Wiekszosc z nich byla cieta, co oznaczalo ze oprawcy zadali je sztyletem, badz nozem. Mial rowniez siniaki i sliwe pod okiem")
        print("Po fali euforii przyszla pora by sie wydostac z tego miejsca. Twoj brat zabral sztylet z zwlok maga i powiedzial, ze jest gotowy")
    print("Zeby uciec z opuszczonej fabryki musicie przejsc przez kompleks naukowy syndykatu. Najrozniejsze trucizny, zaklecia, klatwy i inne machinacje byly tam testowane na ludziach. Brat opowiada ci jak co noc slyszal krzyki torturowanych ludzi. Proponuje ci zniszczenie tego miejsca. 1 - Zgadzasz sie; 2 - Ucieczka jest najwazniejsza") #Rozdzial 4
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Zgadzasz sie; 2 - Ucieczka jest najwazniejsza")
        Wybor = int(input())
    if Wybor == 1:
        print("Kompleks naukowy skalda sie z trzech glownych sekcji. Sekcji testow, gdzie jak sama nazwa mowi rozne eksperymenty sa testowane na ludziach. Sekcji wieziennej, gdzie trzymane sa okazy w oczekiwaniu na test i ostatnia. Sekcja agonii, to tam trafia wszyscy ludzie i czekaja na smierc wraz z innymi juz dawno gnijacymi trupami")
        print("Zaczynacie od sekcji testow. Szybkim krokiem wywazacie drzwi i atakujecie stojacych tam ludzi, twoj brat szybkim ruchem sztyletu zabil trzech wrogow, jednak tobie przyszlo walczyc z bardziej wyszkolonym oddzialem")
        PrzeciwnikGry = Przeciwnik()
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Po walce, wraz z bratem odnajdujecie najnowszy wynalazek syndykatu. Ogromne kanistry z trucizna, ktora testowali. Szybkim wspolnym ruchem niszczycie kanistry i udajcie sie do nastepnej sekcji.")
        print("Kolejne hordy przeciwnikow rzucaja sie na was.")
        PrzeciwnikGry = Przeciwnik()
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Po pokonaniu ich przyszla pora na uwolnienie wiezniow. Ci dziekuja ci bardzo mocno. Ku twemu zdziwniu jeden tajemniczy wiezien wyciaga spod koszulki krysztal zycia. Powiedzial, ze nie ma sil na ucieczke, i ze tobie sie bardziej przyda. 1 - Przyjmij; 2 - Odmow przyjecia")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Przyjmij; 2 - Odmow przyjecia")
            Wybor = int(input())
        if Wybor == 1:
            Gracz.DodawanieHP(5)
            Gracz.Leczenie(Gracz.MaksHP)
        print("To jednak nie koniec. Zostala ostatnia sekcja. Najgorsza z nich. Na dziesiec metrow przed wejsciem smierdzialo zgniliznal. Kiedy zas wszedles twym oczom ukazaly sie gory ludzkich cial. Martwych cial. Ujrzales tez wyjscie. Zadowolony z sukcesu biegniesz wraz z innymi uciekinierami")
        print("Wszystko co piekne szybko sie konczy , a na twej drodze staneli straznicy syndykatu. Najbardziej elitarni zolnierze, ktorym przewodzil kapitan. Wielki jak dwie gory i oczywiscie chcial walczyc z toba. Z lekkim usmieszkiem lecisz w wir walki")
        PrzeciwnikGry = Przeciwnik(150, 2, 2)
        Walka(Gracz, PrzeciwnikGry)
        if Gracz.AktualneHP <= 0:
            return 0
        print("Do ciala rycerza byla przypieta mala skrzynka. Sila ja otworzyles i twym oczom ukazal sie krysztal zycia. To dlatego wojownik mial tyle sily. 1 - Przyjmij; 2 - Zostaw")
        Wybor = int(input())
        while Wybor != 1 and Wybor != 2:
            print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Przyjmij; 2 - Zostaw")
            Wybor = int(input())
        if Wybor == 1:
            Gracz.DodawanieHP(10)
            Gracz.Leczenie(Gracz.MaksHP)
        print("Wycienczony po tej walce, jednak zadowolony z wygranej uciekasz z opuszczonej fabryki, wielkiego kompleksu syndykatu. Szybko znajdujesz swego konia i wraz z bratem uciekasz z tego przekletego miejsca")
    else:
        print("Skradacie sie przez wielkie labolatorium. Slyszac krzyki cierpiacych ludzi. Zal ci tych ludzi jednak nie jestes w stanie nic zrobic. Ucieczka z bratem jest najwazniejsza.")
        print("Przechodzicie obok luzek przerazonych ludzi, ktorzy niedlugo beda poddawani tym potwornym zabiegom. Schowani za sciana, przysluchujecie sie ich modlitwo, jekom placzowi.")
        print("Przchodzicie obok wielkich gor ludzkiego miesa. Zdajesz sobie sprawe, ze tamtych ludzi tez czeka taki los.")
        print("Udaje wam sie bez spostrzerzenia wydostac z kompleksu. Wsiadacie na konia i z tego przekletego miejsca")
    print("Podczas jazdy ustalacie wspolnie, ze nie mozecie zostac w miescie. Jesli syndykat sie dowie co sie stalo. Uzyje wszystkich dostepnych srodkow by ich zabic. Jedynym wyjsciem jest ucieczka gdzie was nie znajda")   #Rozdzial 5
    print("Zostal wybor rodzaju transportu. Traktat handlowy odpada, poniewaz tam bedzie wielu czlonkow syndykatu. Mozna sie przebic lodka przez Gleboki Kanal i wyladawac po drugiej stronie, skad latwo wejsc do lasu, jednak bedzie trzeba znalezc kapitana. Albo mniejsza brama jednak tam tez moga byc wojska syndykatu")
    print("Jaka decyzje podjemujesz? 1 - Droga morska; 2 - Przez brame")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Droga morska; 2 - Przez brame")
        Wybor = int(input())
    if Wybor == 1:
        print("Port Wielkiego Miasta Kupieckiego skrywal wiele tajemnic. Niektorzy ludzie jak tylko postawili tam stope zostali bogaczami. Inni na miejscu umarli")
        print("Waszym zadaniem bylo znalezc kapitana, a przy okazji nie dac sie zabic.")
        print("Po wielu godzinach nie udalo sie znalezc kapitana az wreszcie przy jednej z mniejszych lodek znalazl sie ten co was uratuje.")
        print("Byl to dosc specyficzny kapitan. Mial dluga ruda brode i papuge ktora co ruszt gdekala rozne glupoty. Jednak cokolwiek jest lepsze niz nic i zdecydujecie sie ruszyc.")
        print("Po kilku godzinach spokojnej zeglugi udaje sie wam doplynac na drugi brzeg gdzie rozstajecie sie z kapitanem.")
    else:
        print("Przy bramie jak zwykle nie bylo zbyt duzego ruchu. Straznicy nawet kiedy wstawal ranek i slonce grzalo po twarzach spali nie wzruszeniu opierajac sie o miecze.")
        print("Po oddaleniu sie na kilkanascie metrow od bramy przycwalowales koniem i udalo sie schowac w lesie.")
        print("Zadowoleni z uddanej ucieczki z laboratorium zatrzymaliscie sie, wymieniliscie sie zdaniem i powspominaliscie stare czasy kiedy to byliscie razem.")
    print("Stales teraz na rozdrozu. Zaczeles myslec, ze jeszcze kilka godzin temu nie wiezyles czy twoj brat zyje, a teraz stoisz z nim i rozmawiasz. Tej jednej nocy zmienilo sie wiele w twoim zyciu. Zdales sobie sprawe, ze twoj brat nie jest juz tym malym dzieckiem, ktore zostawiles w miescie. W glebi serca zawsze to wiedziales. Dlatego nie bales sie go zostawiac.")  #Rozdzial 6
    print("Przez glowe przemyka ci niepewna mysl. Zycie w miescie to jedno, ale zycie w podrozy to calkiem co innego. Jednak widziales jak walczyl, a gdy pozostanie w miescie syndykat moze go znalezc.")
    print("Jaka decyzje podejmujesz? 1 - Zaproponuj bratu zycie z nim lecz ciagle zycie w podrozy; 2 - Daj bratu troche pieniedzy i powiedz by wrocil do miasta")
    Wybor = int(input())
    while Wybor != 1 and Wybor != 2:
        print("Nie rozumiem co mowisz. Czy mozesz powtorzyc? 1 - Zaproponuj bratu zycie z nim lecz ciagle zycie w podrozy; 2 - Daj bratu troche pieniedzy i powiedz by wrocil do miasta")
        Wybor = int(input())
    if Wybor == 1:
        print("Brat bardzo sie cieszy z twojej propozycji i wspolnie wsiadacie na konia by pojechac na kolejna przygode")
        print("Koniec Gry - Wygrana! Gratulujemy ci przejscia tej gry. Sa rowniez inne drogi, ktorymi fabula moze sie potoczyc, zachecamy do ponownego zagrania. A raczej do kolejnego zagrania :)")
        return 0
    else:
        print("Brat przyjmuje pieniadze, dziekuje ci i mowi ze na pewno sie przydadza jednak nie zamierza wracac do miasta. Opowiada ci o pewnej dziewczynie ktora spotkal w krolestwie Elfow i mowi ze tam teraz sie uda. Ty zyczysz mu powodzenia i odjezdzacie w dwie rozne strony")
        print("Koniec Gry - Wygrana! Gratulujemy ci przejscia tej gry. Sa rowniez inne drogi, ktorymi fabula moze sie potoczyc, zachecamy do ponownego zagrania. A raczej do kolejnego zagrania :)")
        return 0



#Odtwarzanie funckji z gra i faktyczna gra.

WyborKlasy = StartGryIWyborPostaci()
if WyborKlasy == 1:
    Gracz = Wojownik()
elif WyborKlasy == 2:
    Gracz = Lucznik()
else:
    Gracz = Mag()
WyborKampani = PoczatekGryKarczma()
if WyborKampani == 1:
    Zlecenie()
elif WyborKampani == 2:
    Brat()