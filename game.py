import pygame

class data:
  def __init__(self):
    pygame.init()
    self.WIDTH = 900
    self.HEIGHT = 600
    self.BLACK = (0, 0, 0)
    self.FPS = 60
    self.clock = pygame.time.Clock()

    # colors
    self.RED = (255, 0, 0)
    self.GREEN = (0, 255, 0)
    self.YELLOW = (255, 255, 0)
    self.MEGENTA = (255, 0, 255)
    self.WHITE = (255, 255, 255)
    self.BLACK = (0, 0, 0)
    self.win = pygame.display.set_mode((self.WIDTH,self.HEIGHT))
    pygame.display.set_caption("Pong game")

class Line(data):
    def __init__(self):
        super(Line, self).__init__()
        self.width= self.WIDTH
        self.height = 5
        self.x = 0
        self.y = 40
        self.line = pygame.Rect(self.x, self.y, self.width, self.height)

    def drawline(self):

       pygame.draw.rect(self.win,self.MEGENTA,self.line)

class LeftPlayer(data):
    def __init__(self):
        super(LeftPlayer, self).__init__()
        self.width = 10
        self.height = 40
        self.lx = 0
        self.ly = int(self.HEIGHT / 2 - self.height / 2)
        self.rect = pygame.Rect(self.lx, self.ly, self.width, self.height)
        self.speed = 10

    def drawrect(self):
        pygame.draw.rect(self.win, self.RED, self.rect)


    def move(self):
        key = pygame.key.get_pressed()
        if key[pygame.K_z] and self.HEIGHT - 40 > self.rect.y:
            self.rect.y += self.speed
        if key[pygame.K_w] and self.rect.y > 50:
            self.rect.y -= self.speed


class RightPlayer(data):
    def __init__(self):
        super(RightPlayer, self).__init__()
        self.width = 10
        self.height = 40
        self.rx = self.WIDTH - 10
        self.ry = int(self.HEIGHT / 2 - self.height / 2)
        self.rect = pygame.Rect(self.rx, self.ry, self.width, self.height)
        self.speed = 10

    def drawrect(self):
        pygame.draw.rect(self.win, self.GREEN, self.rect)

    def move(self):
        keys = pygame.key.get_pressed()
        if keys[pygame.K_DOWN] and self.HEIGHT - 40 > self.rect.y:
            self.rect.y += self.speed
        if keys[pygame.K_UP] and self.rect.y > 50:
            self.rect.y -= self.speed


class ball(data):
    def __init__(self):
        super(ball, self).__init__()
        self.radius = 10
        self.x = self.WIDTH // 2
        self.y = self.HEIGHT // 2
        self.rect = pygame.Rect(self.x, self.y, self.radius * 2, self.radius * 2)
        self.dx = 4
        self.dy = 4
        self.leftscore = 0
        self.rightscore = 0

    def draw(self):

        pygame.draw.circle(self.win, self.WHITE, (self.rect.x, self.rect.y), self.radius, 20, False, False, False, False)

    def move(self):
        self.rect.x += self.dx
        self.rect.y += self.dy
        wall = pygame.mixer.Sound("D:/pong game/sounds/bounce.mp3")
        if self.rect.y >= self.HEIGHT:
            self.dy *= -1
            wall.play()

        if self.rect.x >= self.WIDTH:
            self.dx *= -1
            wall.play()
        if self.rect.y <= 50:
            self.dy *= -1
            wall.play()
        if self.rect.x <= 0:
            self.dx *= -1
            wall.play()

    def collition(self,left,right):


        if self.rect.colliderect(left) and self.dx < 0 :
            self.rect.x = 20
            self.dx *= -1
            hitting = pygame.mixer.Sound("D:/pong game/sounds/hitting.mp3")
            hitting.play()
            self.leftscore += 1

        if (self.rect.colliderect(right) and self.rect.x < self.WIDTH - left.width) and self.rect.x != self.WIDTH and self.dx > 0:
            # self.rect.x = 10
            self.dx *= -1
            hitting = pygame.mixer.Sound("D:/pong game/sounds/hitting.mp3")
            hitting.play()
            self.rightscore += 1
        return [self.leftscore, self.rightscore]





class scorecal(data):

    def __init__(self):
        super(scorecal, self).__init__()
        self.b = ball()

    def left_win(self):
        if self.score[0] > self.score[1]:
            lwinner = self.score[0] - self.score[1]
            if lwinner >= 5:
                # winner display
                font = pygame.font.Font('freesansbold.ttf', 32)
                text = font.render('Winner is Left Player', True, self.GREEN, self.YELLOW)
                textRect = text.get_rect()
                textRect.center = (self.WIDTH // 2, self.HEIGHT // 2)
                self.win.blit(text, textRect)


    def right_win(self):
        if self.score[1] > self.score[0]:
            rwinner = self.score[1] - self.score[0]
            if rwinner >= 5:
                # winner text
                font = pygame.font.Font('freesansbold.ttf', 32)
                text = font.render('Winner is Right Player', True, self.GREEN, self.YELLOW)
                textRect = text.get_rect()
                textRect.center = (self.WIDTH // 2, self.HEIGHT // 2)
                self.win.blit(text, textRect)



    def score_disp(self,s):
        score = s
        font = pygame.font.Font('freesansbold.ttf', 25)
        text = font.render("Left = " + str(score[0]) + " : Right = " + str(score[1]), True, self.WHITE, self.BLACK)
        textRect = text.get_rect()
        textRect.center = (self.WIDTH // 2, 15)
        self.win.blit(text, textRect)
        pygame.display.update()



def gstart():
        d = data()
        left= LeftPlayer()
        right = RightPlayer()
        cir = ball()
        li = Line()
        score = scorecal()
        run = True
        while run:

            d.win.fill(d.BLACK)
            li.drawline()
            left.drawrect()
            left.move()
            right.drawrect()
            right.move()
            cir.draw()
            cir.move()
            coli_count = cir.collition(left, right)
            d.clock.tick(d.FPS)

            score.score_disp(coli_count)
            pygame.display.update()

            for event in pygame.event.get():

                if event.type == pygame.QUIT:
                    run = False

        pygame.quit()

gstart()



