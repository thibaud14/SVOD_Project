# encoding: utf-8

# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the rake db:seed (or created alongside the db with db:setup).
#
# Examples:
#
#   cities = City.create([{ name: 'Chicago' }, { name: 'Copenhagen' }])
#   Mayor.create(name: 'Emanuel', city: cities.first)
    user = User.create(name: "vdc", email: "vince@gmail.com", password: "aaaaaa", password_confirmation: "aaaaaa")

# Autogenerated by the db:seed:dump task
# Do not hesitate to tweak this to your needs
# encoding: utf-8
# Autogenerated by the db:seed:dump task
# Do not hesitate to tweak this to your needs

@cols = Collection.create([
  { :name => "The Big Bang Theory", :year => 2007, :created_at => nil, :updated_at => nil }
], :without_protection => true )

@genres = Genre.create([
  { :name => "Comedy", :created_at => nil, :updated_at => nil }
], :without_protection => true )


@langs = Langue.create([
  { :name => "ENG", :created_at => nil, :updated_at => nil }
], :without_protection => true )


@subs = Subtitle.create([
  { :name => "FR", :created_at => nil, :updated_at => nil }
], :without_protection => true )


User.create([
  { :name => "mousquetaire", :email => "mous@svodbe.be", :password => "P@ssw0rd", :password_confirmation => "P@ssw0rd",
    :created_at => nil, :updated_at => nil }
], :without_protection => true )



Video.create([
  { :thumbnail_url => "http://fanart.tv/fanart/tv/80379/seasonthumb/B_80379%20(3).jpg", :type_video => "Serie", :title => "La fluctuation de l'ouvre-boîte électrique", :year => 2009, :duration => 1380, :country => "USA", :video_url => "http://vps.vincex86.be/videos/bbt/3/bbts03E02/bbts03E01.ism/manifest", :bo_url => "http://www.wat.tv/video/the-big-bang-theory-bande-1upid_2exzl_.html", :synopsis => "Sheldon rentre au Texas en disgrâce quand il apprend que ses camarades ont altéré les données de son expédition dans l'Arctique...", :position => 1, :tagline => "humour#rire#sheldon#leaonard#tbbt#big#bang", :season => 3, :star_rating_avg => 2.8,
    :collection => @cols.first, :langues => @langs, :subtitles => @subs, :genres => @genres,
  :created_at => nil, :updated_at => nil }],
  :without_protection => true )

Video.create([
  { :thumbnail_url => "http://fanart.tv/fanart/tv/80379/seasonthumb/B_80379%20(3).jpg", :type_video => "Serie", :title => "Le Grillon des champs", :year => 2009, :duration => 1380, :country => "USA", :video_url => "http://vps.vincex86.be/videos/bbt/3/bbts03E02/bbts03E02.ism/manifest", :bo_url => "http://www.wat.tv/video/the-big-bang-theory-bande-1upid_2exzl_.html", :synopsis => "La première nuit de Leonard et Penny ne se déroule pas réellement comme ils l'imaginaient. Sheldon et Howard sont en désaccord sur la nature d'un criquet et décident de parier les comics auxquels ils tiennent le plus.", :position => 2, :tagline => "humour#rire#sheldon#leaonard#tbbt#big#bang", :season => 3, :star_rating_avg => 3.8,
    :collection => @cols.first, :langues => @langs, :subtitles => @subs, :genres => @genres,
    :created_at => nil, :updated_at => nil }],
    :without_protection => true )

Video.create([
  { :thumbnail_url => "http://fanart.tv/fanart/tv/80379/seasonthumb/B_80379%20(3).jpg", :type_video => "Serie", :title => "La déviation Gotowitz", :year => 2009, :duration => 1380, :country => "USA", :video_url => "http://vps.vincex86.be/videos/bbt/3/bbts03E02/bbts03E03.ism/manifest", :bo_url => "http://www.wat.tv/video/the-big-bang-theory-bande-1upid_2exzl_.html", :synopsis => "Sheldon tente de faire retrouver à Penny sa bonne humeur avec des chocolats afin qu'elle soit plus gentille envers lui. Raj et Howard décident de s'habiller façon «gothique» afin d'aller draguer dans un night club.", :position => 3, :tagline => "humour#rire#sheldon#leaonard#tbbt#big#bang", :season => 3, :star_rating_avg => 3.8,
    :collection => @cols.first, :langues => @langs, :subtitles => @subs, :genres => @genres,
  :created_at => nil, :updated_at => nil }],
  :without_protection => true )