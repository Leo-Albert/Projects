# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'windowseniWOf.ui'
##
## Created by: Qt User Interface Compiler version 5.15.2
##
## WARNING! All changes made in this file will be lost when recompiling UI file!
################################################################################


from PySide2.QtCore import *
from PySide2.QtGui import *
from PySide2.QtWidgets import *
from PyQt5 import QtWidgets
import sys
import game
import Settings


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        if not MainWindow.objectName():
            MainWindow.setObjectName(u"MainWindow")
        MainWindow.resize(399, 299)
        font = QFont()
        font.setFamily(u"Microsoft Himalaya")
        font.setPointSize(14)
        MainWindow.setFont(font)
        self.centralwidget = QWidget(MainWindow)
        self.centralwidget.setObjectName(u"centralwidget")
        self.verticalLayout = QVBoxLayout(self.centralwidget)
        self.verticalLayout.setObjectName(u"verticalLayout")
        self.newbt = QPushButton(self.centralwidget)

        self.newbt.setObjectName(u"newbt")

        self.verticalLayout.addWidget(self.newbt)

        self.exit = QPushButton(self.centralwidget)
        self.exit.setObjectName(u"exit")

        self.verticalLayout.addWidget(self.exit)

        self.settings = QPushButton(self.centralwidget)
        self.settings.setObjectName(u"settings")

        self.verticalLayout.addWidget(self.settings)

        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QMenuBar(MainWindow)
        self.menubar.setObjectName(u"menubar")
        self.menubar.setGeometry(QRect(0, 0, 399, 25))
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QStatusBar(MainWindow)
        self.statusbar.setObjectName(u"statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)

        QMetaObject.connectSlotsByName(MainWindow)
    # setupUi

    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(QCoreApplication.translate("MainWindow", u"Pong Game", None))
        self.newbt.setText(QCoreApplication.translate("MainWindow", u"NEW", None))
#if QT_CONFIG(shortcut)
        self.newbt.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+N", None))
#endif // QT_CONFIG(shortcut)
        self.exit.setText(QCoreApplication.translate("MainWindow", u"EXIT", None))
#if QT_CONFIG(shortcut)
        self.exit.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+E", None))
#endif // QT_CONFIG(shortcut)
        self.settings.setText(QCoreApplication.translate("MainWindow", u"SETTINGS", None))
#if QT_CONFIG(shortcut)
        self.settings.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+S", None))
#endif // QT_CONFIG(shortcut)
    # retranslateUi
    def exitapp(self):
        QApplication.exit()

class App(Ui_MainWindow,QMainWindow):
    def __init__(self):
        super(App,self).__init__()
        self.setupUi(self)
        self.show()
        self.newbt.clicked.connect(game.gstart)
       # self.exit.clicked.connect(self.exitapp)
        self.settings.clicked.connect(Settings.start_settinngs)

app = QtWidgets.QApplication([])
w = App()
sys.exit(app.exec_())









